using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class landing : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usertype"] == null)
                {
                    LinkButton4.Visible = true; //user login

                    LinkButton5.Visible = false; //logout
                    LinkButton6.Visible = false; //hello user
                }
                else if ((Session["usertype"].ToString() == "Student") || (Session["usertype"].ToString() == "Landlord") || (Session["usertype"].ToString() == "Admin"))
                {
                    LinkButton4.Visible = false; //user login

                    LinkButton5.Visible = true; //logout
                    LinkButton6.Visible = true; //hello user
                    LinkButton6.Text = "Hello "+ Session["name"].ToString();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        //logout
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Session["email"] = "";
            Session["fname"] = "";
            Session["usertype"] = "";
            Session["accountstatus"] = "";

            LinkButton4.Visible = true; //user login

            LinkButton5.Visible = false; //logout
            LinkButton6.Visible = false; //hello user

            Response.Write("<script>alert('Login Successful.');</script>");
            Response.Redirect("home.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }
    }
}