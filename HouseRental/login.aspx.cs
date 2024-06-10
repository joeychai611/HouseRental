using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace HouseRental
{
    public partial class login : System.Web.UI.Page
    {
        protected static string ReCaptcha_Key = "6Lf6Y_MpAAAAAFS-KK7s__ylaLbnMwrMfLAxpyG7";
        protected static string ReCaptcha_Secret = "6Lf6Y_MpAAAAAOmgzi34CimsFLv3NUcVyYavle3g";

        [WebMethod]
        public static string VerifyCaptcha(string response)
        {
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            return (new WebClient()).DownloadString(url);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string password = TextBox2.Text;

            if (IsValidLogin(email, password))
            {
                Response.Write("<script>alert('Login Successful.');</script>");

                string userType = Session["usertype"]?.ToString();
                if (userType == "Student")
                {
                    Response.Redirect("sdashboard.aspx");
                }
                else if (userType == "Landlord")
                {
                    Response.Redirect("ldashboard.aspx");
                }
                else if (userType == "Admin")
                {
                    Response.Redirect("admindashboard.aspx");
                }
                else
                {
                    Response.Write("<script>alert('User type not recognized.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }
        }

        protected bool IsValidLogin(string email, string enteredPassword)
        {
            try
            {
                string hashedPasswordFromDatabase;
                string salt;
                string userType;
                string name;

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT password, salt, usertype, name FROM people WHERE email = @email";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hashedPasswordFromDatabase = reader["password"].ToString();
                                salt = reader["salt"].ToString();
                                userType = reader["usertype"].ToString();
                                name = reader["name"].ToString();
                            }
                            else
                            {
                                // User not found, login failed
                                return false;
                            }
                        }
                    }
                }

                // Hash the entered password with the retrieved salt
                string enteredPasswordHash = HashPassword(enteredPassword, salt);

                // Compare the hashed passwords
                if (string.Equals(hashedPasswordFromDatabase, enteredPasswordHash))
                {
                    // Set session variables after successful login
                    Session["email"] = email;
                    Session["usertype"] = userType;
                    Session["name"] = name;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, show user-friendly error, etc.)
                return false;
            }
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