using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Login Successful.');</script>");
            try
            {
                SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from people where email='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["email"] = dr.GetValue(2).ToString();
                        Session["name"] = dr.GetValue(1).ToString();
                        Session["usertype"] = dr.GetValue(6).ToString();
                        Session["accountstatus"] = dr.GetValue(9).ToString();
                    }
                    Response.Write("<script>alert('Login Successful.');</script>");

                    if (Session["usertype"].ToString() == "Student")
                    {
                        Response.Redirect("sdashboard.aspx");
                    }
                    else if (Session["usertype"].ToString() == "Landlord")
                    {
                        Response.Redirect("ldashboard.aspx");
                    }
                    else if (Session["usertype"].ToString() == "Admin")
                    {
                        Response.Redirect("admindashboard.aspx");
                    }
                    else
                    {

                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }
    }
}