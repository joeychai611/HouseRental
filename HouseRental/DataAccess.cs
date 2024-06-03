using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace HouseRental
{
    public class DataAccess
    {
        private static string salt = "key";
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
        
        private string GenerateHash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            SHA256Managed sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public LoginStatus CheckLogin(string email, string pw)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from consumer where email=@email AND password=@password", con);
                var hash = GenerateHash(pw);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hash);
                using(var read = cmd.ExecuteReader())
                {
                    if (!string.IsNullOrEmpty(read["code"] + string.Empty))
                    { 
                        return LoginStatus.NeedVerify;
                    }
                    else if (!string.IsNullOrEmpty(read["email"] + string.Empty))
                    {
                        return LoginStatus.OK;
                    }
                    else
                    {
                        return LoginStatus.Incorrect;
                    }
                }
            }
            return LoginStatus.NotExist; 
        }

        public bool Register(string email, string pw)
        {
            LoginStatus loginStatus = CheckLogin(email, pw);
            if(loginStatus == LoginStatus.NotExist)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    var hash = GenerateHash(pw);
                    var code = new Random().Next(9999);
                    string insertQuery = "INSERT INTO consumer(email,password,code) VALUES(@email,@password,@code)";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hash);
                    cmd.Parameters.AddWithValue("@code", code);
                    var mailhelp = new EmailRegister();
                    mailhelp.Send(code+string.Empty, email);
                    return cmd.ExecuteNonQuery() >0;
                }
            }
            return false;
        }

        public bool VerifyCode(string email, string password, string code)
        {
            LoginStatus loginStatus = CheckLogin(email, password);
            if (loginStatus != LoginStatus.NeedVerify) return false;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                var cmd = new SqlCommand("SELECT code FROM consumer WHERE email= @email", con);
                cmd.Parameters.AddWithValue("@email", email);
                if (cmd.ExecuteScalar().ToString() == code)
                {
                    var cmdUpdate = new SqlCommand("UPDATE consumer SET code = NULL WHERE email=@email", con);
                    cmdUpdate.Parameters.AddWithValue("@email", email);
                    return cmdUpdate.ExecuteNonQuery() > 0;
                }
            }
            return false;

        }
    }
}