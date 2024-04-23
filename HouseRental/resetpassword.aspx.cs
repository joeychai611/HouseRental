using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class resetpassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"].ToString();

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
                con.Open();
                string updateAcc = "UPDATE people SET password='"+ TextBox1.Text.ToString() +"' WHERE email='" + email + "'";
                using (SqlCommand cmdUpdate = new SqlCommand(updateAcc, con))
                {
                    cmdUpdate.ExecuteNonQuery();
                }
 
                string updateToken = "UPDATE resetpassword SET token=0 WHERE email='" + email + "'";
                using (SqlCommand cmdUpdate = new SqlCommand(updateToken, con))
                {
                    cmdUpdate.ExecuteNonQuery();
                }
                Response.Write("<script>alert('Password reset successfully. Login now.');</script>");
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('New password and confirm password is not same.');</script>");
                con.Close();
            }
        }
    }
}