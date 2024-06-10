using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Services;

namespace HouseRental
{
    public partial class register : System.Web.UI.Page
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

        //register button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkEmptyBox())
            {
                if (checkUserExists())
                {
                    Response.Write("<script>alert('Email Exists. Login now or try another email.');</script>");
                }
                else
                {
                    string email = TextBox2.Text;
                    string password = TextBox5.Text;
                    string salt = GenerateSalt();
                    string hashedPassword = HashPassword(password, salt);

                    registerNewUser(email, hashedPassword, salt);
                }
            }
        }

        //user defined method
        bool checkEmptyBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                if (TextBox2.Text.Trim() != string.Empty)
                {
                    if (TextBox3.Text.Trim() != string.Empty)
                    {
                        if (TextBox7.Text.Trim() != string.Empty)
                        {
                            if (TextBox5.Text.Trim() != string.Empty)
                            {
                                if (TextBox6.Text.Trim() != string.Empty)
                                {
                                    if (TextBox5.Text.Trim() == TextBox6.Text.Trim())
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Please fill in Same Password.');</script>");
                                        return false;
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Please fill in Confirm Password.');</script>");
                                    return false;
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Please fill in Password.');</script>");
                                return false;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill in IC.');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in Contact Number.');</script>");
                        return false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please fill in Email Address.');</script>");
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        void registerNewUser(string email, string hashedPassword, string salt)
        {
            Random random = new Random();
            int myRandom = random.Next(10000000, 99999999);
            string activationcode = myRandom.ToString();

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string insertQuery = "INSERT INTO people VALUES(@name,@email,@contactnum,@dateofbirth,@gender,@usertype,@password,@accountstatus,@activationcode,@is_active,@ic,@salt)";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                if (DropDownList2.SelectedItem.Text == "Student")
                {
                    cmd.Parameters.AddWithValue("@accountstatus", "Pending");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@accountstatus", "Active");
                }
                cmd.Parameters.AddWithValue("@activationcode", activationcode);
                cmd.Parameters.AddWithValue("@is_active", 0);
                cmd.Parameters.AddWithValue("@ic", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@salt", salt);

                cmd.ExecuteNonQuery();

                MailMessage mail = new MailMessage();
                mail.To.Add(TextBox2.Text.ToString().Trim());
                mail.From = new MailAddress("joeychai0611@gmail.com");
                mail.Subject = "Welcome to House Rental!";

                string emailBody = "";

                emailBody += "<h2>Hello " + TextBox1.Text.ToString() + ",</h2>";
                emailBody += "We're so glad you decided to join House Rental! ";
                emailBody += "It's a pleasure to welcome you to our growing family.<br>"; 
                emailBody += "<br>";
                emailBody += "Click below link for activate your account.";
                emailBody += "<p><a href='" + "https://localhost:44358/activateaccount.aspx?activationcode=" + activationcode + "&email=" + TextBox2.Text.ToString() + "'>Click Here To Activate</a></p>";
                emailBody += "If you have any questions or need assistance, please don't hesitate to reach out to our moderators or admins.";
                emailBody += "We're here to help!<br>"; 
                emailBody += "Thank You.";
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

                Response.Write("<script>alert('Register successfully. Please check your email for activation link.');</script>");

                con.Close();

                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.SelectedValue = "Male";
            DropDownList2.SelectedValue = "Student";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
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