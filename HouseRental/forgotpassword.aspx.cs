using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace HouseRental
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID from people where email='" + TextBox1.Text.Trim() + "' AND is_active=1;", con);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read()) 
                {
                    con.Close();
                    Random random = new Random();
                    int myRandom = random.Next(10000000, 99999999);
                    string token = myRandom.ToString();

                    con.Open();
                    string insertUpload = "INSERT INTO resetpassword (email,token,validatedate) VALUES (@email,@token,@validatedate)";
                    SqlCommand insertCmd = new SqlCommand(insertUpload, con);
                    insertCmd.Parameters.AddWithValue("@email", TextBox1.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@token", token);
                    insertCmd.Parameters.AddWithValue("@validatedate", DateTime.Now.AddMinutes(15));
                    insertCmd.ExecuteNonQuery();
                    insertCmd.Dispose();
                    con.Close();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(TextBox1.Text.ToString().Trim());
                    mail.From = new MailAddress("joeychai0611@gmail.com");
                    mail.Subject = "Reset Password for House Rental";

                    string emailBody = "";

                    emailBody += "<h2>Hello " + TextBox1.Text.ToString() + ",</h2>";
                    emailBody += "Click below link for reset your password.<br>";
                    emailBody += "<p><a href='" + "https://localhost:44358/resetpassword.aspx?token=" + token + "&email=" + TextBox1.Text.ToString() + "'>Click Here To Reset Password</a></p>";
                    emailBody += "<br>Thank You.";
                    emailBody += "<br><br>";
                    emailBody += "Regards,<br>";
                    emailBody += "House Rental Team";

                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587; // 25 465
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new System.Net.NetworkCredential("joeychai0611@gmail.com", "pkte keth bwzc kcwj");
                    smtp.Send(mail);

                    Response.Write("<script>alert('Reset password link successfully. Please check your email for reset password.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Your email is not associated.');</script>");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}