using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HouseRental
{
    public partial class paymentGateway : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || string.IsNullOrEmpty(Session["email"].ToString()))
            {
                Response.Write("<script>alert('Session expired, login again.');</script>");
                Response.Redirect("login.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                int studentID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session.Add("ID", studentID);

                string details = Request.QueryString["details"];
                string price = Request.QueryString["price"];
                string latefee = Request.QueryString["latefee"];
                string total = Request.QueryString["total"];
                Label1.Text = details;
                Label2.Text = price;
                Label3.Text = latefee;
                Label4.Text = total;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkEmptyBox())
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand Cmd = new SqlCommand("SELECT * from payment WHERE details='" + Label1.Text.Trim() + "' AND studentID='" + Session["ID"].ToString() + "'", con);
                SqlDataAdapter daa = new SqlDataAdapter(Cmd);
                DataTable dtt = new DataTable();
                daa.Fill(dtt);
                Label5.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Label6.Text = Label1.Text;
                Label7.Text = "Credit Card";
                Label8.Text = dtt.Rows[0]["total"].ToString();
                Label9.Text = dtt.Rows[0]["ID"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE payment SET status=@status, paymentdate=@paymentdate WHERE details='" + Label1.Text + "' AND studentID='" + Session["ID"].ToString() + "';", con);

                cmd.Parameters.AddWithValue("@status", "Completed");
                cmd.Parameters.AddWithValue("@paymentdate", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openCModal();", true);
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentPayment.aspx");
        }

        bool checkEmptyBox()
        {
            try
            {
                if (TextBox1.Text.Trim() != string.Empty)
                {
                    if (TextBox2.Text.Trim() != string.Empty)
                    {
                        if (TextBox3.Text.Trim() != string.Empty)
                        {
                            if (TextBox4.Text.Trim() != string.Empty)
                            {
                                if (TextBox5.Text.Trim() != string.Empty)
                                {
                                    return true;
                                }
                                else
                                {
                                    Response.Write("<script>alert('Please fill in CVV.');</script>");
                                    return false;
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Please fill in Expiry Date.');</script>");
                                return false;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill in Expiry Date.');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in Card Number.');</script>");
                        return false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please fill in Cardholder Name.');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
    }
}