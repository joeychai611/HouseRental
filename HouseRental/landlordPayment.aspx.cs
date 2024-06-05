using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HouseRental
{
    public partial class landlordPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || string.IsNullOrEmpty(Session["email"].ToString()))
            {
                Response.Write("<script>alert('Session expired, login again.');</script>");
                Response.Redirect("login.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from people WHERE email='" + Session["email"].ToString() + "';", con);
                int userID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session.Add("ID", userID);
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox status = e.Row.Cells[4].FindControl("status") as TextBox;
                if (e.Row.Cells[4].Text == "Pending")
                {
                    e.Row.Cells[4].CssClass = "badge badge-pill badge-warning";
                }
                if (e.Row.Cells[4].Text == "Completed")
                {
                    e.Row.Cells[4].CssClass = "badge badge-pill badge-success";
                }
                if (e.Row.Cells[4].Text == "Due")
                {
                    e.Row.Cells[4].CssClass = "badge badge-pill badge-danger";
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView2.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView2.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView2.SelectedRow.Cells[3].Text;
            ModalPopupExtender1.Show();
            getPaymentDetails();
        }

        void getPaymentDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from payment WHERE details='" + TextBox1.Text.Trim() + "' AND landlordID='" + Session["ID"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["details"].ToString();
                TextBox2.Text = dt.Rows[0]["price"].ToString();
                TextBox3.Text = dt.Rows[0]["date"].ToString();
                TextBox4.Text = dt.Rows[0]["latefee"].ToString();
                TextBox5.Text = dt.Rows[0]["total"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand Cmd = new SqlCommand("UPDATE payment SET total=@total WHERE details='" + TextBox1.Text + "' AND studentID='" + Session["ID"].ToString() + "';", con);

                Cmd.Parameters.AddWithValue("@total", TextBox5.Text);
                Cmd.ExecuteNonQuery();

                if (dt.Rows[0]["status"].ToString() == "Completed")
                {
                    Button2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            string details = TextBox1.Text;
            string price = TextBox2.Text;
            string latefee = TextBox4.Text;
            string total = TextBox5.Text;
            Response.Redirect(string.Format("~/paymentGateway.aspx?details={0}&price={1}&latefee={2}&total={3}", details, price, latefee, total));
        }

        protected void Confirm_View(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);
            GridViewRow row = GridView2.Rows[rowIndex];
            Label2.Text = (row.FindControl("details") as Label).Text;
            Label16.Text = (row.FindControl("studentID") as Label).Text;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from payment WHERE details='" + Label2.Text.Trim() + "' AND studentID='" + Label16.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label1.Text = dt.Rows[0]["paymentdate"].ToString();
            Label2.Text = dt.Rows[0]["details"].ToString();
            Label4.Text = "Credit Card";
            Label5.Text = dt.Rows[0]["total"].ToString();
            Label6.Text = dt.Rows[0]["ID"].ToString();
            Label16.Text = dt.Rows[0]["studentID"].ToString();
            string status = dt.Rows[0]["status"].ToString();

            if (status == "Completed")
            {
                label15.Visible = true;
                label14.Visible = true;
                Label8.Visible = true;
                Label1.Visible = true;
                Label9.Visible = true;
                Label2.Visible = true;
                Label10.Visible = true;
                Label4.Visible = true;
                Label11.Visible = true;
                Label12.Visible = true;
                Label5.Visible = true;
                Label13.Visible = true;
                Label6.Visible = true;

                label7.Visible = false;
            }
            else if (status == "Pending")
            {
                label7.Visible = true;

                label15.Visible = false;
                label14.Visible = false;
                Label8.Visible = false;
                Label1.Visible = false;
                Label9.Visible = false;
                Label2.Visible = false;
                Label10.Visible = false;
                Label4.Visible = false;
                Label11.Visible = false;
                Label12.Visible = false;
                Label5.Visible = false;
                Label13.Visible = false;
                Label6.Visible = false;
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openCModal();", true);
        }
    }
}
