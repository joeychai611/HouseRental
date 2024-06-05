using System;
using System.Configuration;
using System.Data.SqlClient;

namespace HouseRental
{
    public partial class activateaccount : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string activationcode = Request.QueryString["activationcode"].ToString();
            string email = Request.QueryString["email"].ToString();

            con.Open();
            string checkActivation = "SELECT ID FROM people WHERE email='" + email + "' and activationcode='" + activationcode + "' AND activationcode !=0 AND is_active!=1";
            SqlCommand checkCMD = new SqlCommand(checkActivation, con);
            SqlDataReader read = checkCMD.ExecuteReader();
            if (read.Read())
            {
                con.Close();
                con.Open();
                string updateAcc = "UPDATE people SET is_active=1, activationcode=0 where email='"+ email + "'";
                SqlCommand cmdUpdate = new SqlCommand(updateAcc, con);
                cmdUpdate.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Your account is activated successfully. Please login.');</script>");
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Link is expired.');</script>");
                con.Close();
            }
        }
    }
}