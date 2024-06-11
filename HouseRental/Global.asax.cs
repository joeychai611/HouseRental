using Stripe;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

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
            void checkpayment_Elapsed(object source, ElapsedEventArgs ee)
            {
                Task.Run(() =>
                {
                    string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp"); 
                    if (!Directory.Exists(tempPath))
                    {
                        Directory.CreateDirectory(tempPath);
                    }
                    string path = Path.Combine(tempPath, "lastExecution.txt"); 
                    string lastExecutionDate = System.IO.File.Exists(path) ? System.IO.File.ReadAllText(path) : null;
                    if (lastExecutionDate != DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString))
                        {
                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            using (SqlCommand cmd = new SqlCommand($@"SELECT
	* 
FROM
	[dbo].[payment] a
	JOIN people b ON a.studentID=b.ID 
WHERE
	a.status = 'Pending' and DATEADD(MONTH, 1, CONVERT(date, [date])) <='{DateTime.Now:yyyy-MM-dd}'", con))
                            {
                                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                {
                                    using (DataTable dt = new DataTable())
                                    {
                                        da.Fill(dt);
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            using (SqlCommand cmd2 = new SqlCommand("UPDATE payment SET latefee=latefee+15 WHERE ID=@id", con))
                                            {
                                                cmd2.Parameters.AddWithValue("@id", dt.Rows[i]["ID"]);
                                                cmd2.ExecuteNonQuery();
                                                EmailSendManager.SendMail(dt.Rows[i]["email"].ToString(), dt.Rows[i]["name"].ToString(), $"Overdue Rent Payment for ({DateTime.Parse(dt.Rows[i]["date"].ToString()):MM})", $@"Hello ({dt.Rows[i]["name"]}),

You have an overdue payment for ({DateTime.Parse(dt.Rows[i]["date"].ToString()):MM}).
Please click to below link to make your payment
“link”

Thank you for supporting House Rental. Hope you have a good day!

Best regards,
House Rental Team");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        System.IO.File.WriteAllText(path, DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                });
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