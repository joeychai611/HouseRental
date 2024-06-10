using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Security.Cryptography;
using System.Text;

namespace HouseRental
{
    public partial class resetpassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"] == null ? "" : Request.QueryString["email"].ToString();

            con.Open();
            string checkActivation = "SELECT ID FROM people WHERE email='" + email + "'";
            SqlCommand checkCMD = new SqlCommand(checkActivation, con);
            SqlDataReader read = checkCMD.ExecuteReader();
            if (read.Read())
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = true;
                PlaceHolder3.Visible = true;
                PlaceHolder4.Visible = false;
                con.Close();
            }
            else
            {
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = false;
                PlaceHolder3.Visible = false;
                PlaceHolder4.Visible = true;
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"].ToString();
            string email = Request.QueryString["email"].ToString();
            if (TextBox1.Text.ToString() == TextBox2.Text.ToString())
            {
                string salt = GenerateSalt();
                string hashedPassword = HashPassword(TextBox1.Text, salt);
                con.Open();
                string updateAcc = "UPDATE people SET password=@password, salt=@salt WHERE email='" + email + "'";
                using (SqlCommand cmdUpdate = new SqlCommand(updateAcc, con))
                {
                    cmdUpdate.Parameters.AddWithValue("@password", hashedPassword);
                    cmdUpdate.Parameters.AddWithValue("@salt", salt);
                    cmdUpdate.ExecuteNonQuery();
                }

                string updateToken = "UPDATE resetpassword SET token=0 WHERE email='" + email + "'";
                using (SqlCommand cmdUpdate = new SqlCommand(updateToken, con))
                {
                    cmdUpdate.ExecuteNonQuery();
                }
                Response.Write("<script>alert('Password reset successfully. Login now.');</script>");
                Response.Redirect("login.aspx");
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('New password and confirm password is not same.');</script>");
                con.Close();
            }
        }

        protected string GenerateSalt()
        {
            // Generate a random salt (you can use a cryptographically secure random number generator)
            // For simplicity, we are using a simple random string generator here
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var saltChars = new char[16];
            for (int i = 0; i < saltChars.Length; i++)
            {
                saltChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(saltChars);
        }

        protected string HashPassword(string password, string salt)
        {
            // Combine the password and salt
            string combinedPassword = password + salt;

            // Choose the hash algorithm (SHA-256 or SHA-512)
            using (var sha256 = SHA256.Create())
            {
                // Convert the combined password string to a byte array
                byte[] bytes = Encoding.UTF8.GetBytes(combinedPassword);

                // Compute the hash value of the byte array
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("x2"));
                }

                return result.ToString();
            }
        }
    }
}