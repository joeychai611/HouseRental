using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class changepassword : System.Web.UI.Page
    {

        string str = null;
        SqlCommand com;
        byte up;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();
            str = "SELECT * FROM people WHERE email='" + Session["email"].ToString() + "' ";
            com = new SqlCommand(str, con);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                if (TextBox1.Text  == reader["password"].ToString())
                {
                    up = 1;
                }
            }
            reader.Close();
            con.Close();

            if (TextBox1.Text.Trim() != string.Empty)
            {
                if (TextBox2.Text.Trim() != string.Empty)
                {
                    if (TextBox3.Text.Trim() != string.Empty)
                    {
                        if (TextBox2.Text == TextBox3.Text)
                        {
                            if (TextBox1.Text != TextBox2.Text)
                            {
                                if (up == 1)
                                {
                                    con.Open();
                                    str = "UPDATE people SET password=@password WHERE email='" + Session["email"].ToString() + "'";
                                    com = new SqlCommand(str, con);
                                    com.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                                    com.Parameters["@password"].Value = TextBox2.Text;
                                    com.ExecuteNonQuery();
                                    con.Close();
                                    Response.Write("<script>alert('Password successfully updated.');</script>");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Please fill in correct old password.');</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('New password cannot same with old password.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill in same new password and confirm password.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in confirm password.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please fill in new password.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please fill in old password.');</script>");
            }
        }
    }
}