using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Timers;
using Stripe;

namespace HouseRental
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_51NHU1CHEhs4SRxhEUf0sTeb4zLkZGsmNTYrnzO57hBbSrx8xRECvndJfZda4zI9pX9lNvOqUYAMAkmiljmtY2n5l008fvuy52x";

            Timer myTimer = new Timer();
            myTimer.Elapsed += new ElapsedEventHandler(checkpayment_Elapsed);
            myTimer.Interval = 1000 * 60 * 60 * 24;
            myTimer.Enabled = true;

            checkpayment_Elapsed(null, null);
        }

        void checkpayment_Elapsed(object source, ElapsedEventArgs ee)
        {
            Task.Run(() =>
            {
                checkpayment();
            });
        }

        public void checkpayment()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //add payment
                DataTable contract = new DataTable();
                using (SqlCommand cmd = new SqlCommand($@"SELECT * from contract where (duration='1 year' and  DATEADD(year, 1, CONVERT(date, [date])) >='{DateTime.Now:yyyy-MM-dd}' and SUBSTRING([date], 9, 2)='{DateTime.Now:dd}') or (duration='6 months' and  DATEADD(month, 6, CONVERT(date, [date])) >='{DateTime.Now:yyyy-MM-dd}') and SUBSTRING([date], 9, 2)='{DateTime.Now:dd}'", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (contract)
                        {
                            da.Fill(contract);
                        }
                    }
                }
                for (int i = 0; i < contract.Rows.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand($@"SELECT 1 from payment where contractID={contract.Rows[i]["ID"]} and date='{DateTime.Now:yyyy-MM-dd}' and details<>'Deposit'", con))
                    {
                        var exist = cmd.ExecuteScalar();
                        if (exist != null) continue;
                    }
                    using (SqlCommand cmd2 = new SqlCommand(@"INSERT INTO payment VALUES(@details,@price,@date,@status,@studentID,@paymentdate,@latefee,@total,@landlordID,@contractID)", con))
                    {
                        decimal rentprice = 0;
                        int studentID = 0;
                        string studentEmail = "";
                        string studentName = "";
                        int landlordID = 0;
                        DateTime cTime = DateTime.Parse(contract.Rows[i]["date"].ToString());

                        using (SqlCommand cmd = new SqlCommand($@"SELECT rentprice from room where hname='{contract.Rows[i]["house_name"]}'", con))
                            rentprice = Convert.ToDecimal(cmd.ExecuteScalar());
                        using (SqlCommand cmd = new SqlCommand($@"SELECT * from people where name='{contract.Rows[i]["student_name"]}'", con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                using (var dt = new DataTable())
                                {
                                    da.Fill(dt);
                                    studentID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                                    studentEmail = dt.Rows[0]["email"].ToString();
                                    studentName = dt.Rows[0]["name"].ToString();
                                }
                            }
                        }
                        using (SqlCommand cmd = new SqlCommand($@"SELECT ID from people where name='{contract.Rows[i]["landlord_name"]}'", con))
                            landlordID = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd2.Parameters.AddWithValue("@details", $"Rent Payment {Math.Ceiling((DateTime.Now - cTime).TotalDays / 30)}");
                        cmd2.Parameters.AddWithValue("@price", rentprice);
                        cmd2.Parameters.AddWithValue("@date", cTime.AddMonths((DateTime.Now.Month - cTime.Month)).ToString("yyyy-MM-dd"));
                        cmd2.Parameters.AddWithValue("@status", "Pending");
                        cmd2.Parameters.AddWithValue("@studentID", studentID);
                        cmd2.Parameters.AddWithValue("@paymentdate", "");
                        cmd2.Parameters.AddWithValue("@latefee", "0");
                        cmd2.Parameters.AddWithValue("@total", rentprice);
                        cmd2.Parameters.AddWithValue("@landlordID", landlordID);
                        cmd2.Parameters.AddWithValue("@contractID", contract.Rows[i]["ID"]);
                        cmd2.ExecuteNonQuery();
                        EmailSendManager.SendMail(studentEmail, $"Overdue Rent Payment for ({Math.Ceiling((DateTime.Now - cTime).TotalDays / 30)})", $@"<h2>Hello ({studentName}),</h2><br>

You have an overdue payment for ({DateTime.Now:MM}).<br>
Please click to below link to make your payment<br>
“link”<br>

Thank you for supporting House Rental. Hope you have a good day!<br>

Best regards,<br>
House Rental Team");
                    }
                }

                //update payment.latefee
                using (SqlCommand cmd = new SqlCommand($@"SELECT
	* 
FROM
	[dbo].[payment] a
	JOIN people b ON a.studentID=b.ID 
WHERE
	a.status = 'Pending' and [date] ='{DateTime.Now:yyyy-MM-dd}' and (latefee - 15) / 15 <> DATEDIFF(MONTH, date, GETDATE())", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                using (SqlCommand cmd2 = new SqlCommand("UPDATE payment SET latefee=latefee+15,total=total+15 WHERE ID=@id", con))
                                {
                                    cmd2.Parameters.AddWithValue("@id", dt.Rows[i]["ID"]);
                                    cmd2.ExecuteNonQuery();
                                    EmailSendManager.SendMail(dt.Rows[i]["email"].ToString(), $"Overdue Rent Payment for ({DateTime.Parse(dt.Rows[i]["date"].ToString()):MM})", $@"<h2>Hello ({dt.Rows[i]["name"]}),</h2>
You have an overdue payment for ({DateTime.Parse(dt.Rows[i]["date"].ToString()):MM}).<br>
Please click to below link to make your payment<br>
“link”<br>

Thank you for supporting House Rental. Hope you have a good day!<br>

Best regards,<br>
House Rental Team");
                                }
                            }
                        }
                    }
                }

                //email notification
                //1，query late payment data；condition：payment.date  DATEADD(day, 10, CONVERT(date, [date]))==GETDATE() or DATEADD(day, 3, CONVERT(date, [date]))==GETDATE()
                //2，foreach data 。 send email；
            }
        }
        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}