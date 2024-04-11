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
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT password FROM people where password ='" + TextBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (TextBox1.Text.Trim() != string.Empty)
            {
                if (dt.Rows.Count.ToString() == "1")
                {
                    if (TextBox2.Text.Trim() != string.Empty)
                    {
                        if (TextBox3.Text.Trim() != string.Empty)
                        {
                            if (TextBox2.Text == TextBox3.Text)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand("UPDATE people SET password ='" + TextBox3.Text + "' where password ='" + TextBox1.Text + "'", con);
                                cmd.ExecuteNonQuery();

                                con.Close();
                                Response.Write("<script>alert('Successfully Updated.');</script>");
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
                    Response.Write("<script>alert('Please fill in correct old password.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please fill in old password.');</script>");
            }

        }
    }
}