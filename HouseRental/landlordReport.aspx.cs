using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;
using System.Drawing;

namespace HouseRental
{
    public partial class landlordReport : System.Web.UI.Page
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
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

                if (!this.IsPostBack)
                {
                    this.BindGrid();
                    GetChartData();
                }
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM appointment WHERE landlordID='" + Session["ID"].ToString() + "' AND MONTH(appointment_date)= '" + DateTime.Now.Month.ToString() + "' AND YEAR(appointment_date)= '" + DateTime.Now.Year.ToString() + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                }

                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM appointment WHERE landlordID='" + Session["ID"].ToString() + "' AND rental =1"))
                {
                    using (SqlDataAdapter sdaa = new SqlDataAdapter())
                    {
                        Cmd.Connection = con;
                        sdaa.SelectCommand = Cmd;
                        using (DataTable dtt = new DataTable())
                        {
                            sdaa.Fill(dtt);
                            GridView1.DataSource = dtt;
                            GridView1.DataBind();
                        }
                    }
                }

                using (SqlCommand Cmdd = new SqlCommand("SELECT * FROM payment WHERE landlordID='" + Session["ID"].ToString() + "' AND status ='Completed' AND MONTH(paymentdate)= '" + DateTime.Now.Month.ToString() + "' AND YEAR(paymentdate)= '" + DateTime.Now.Year.ToString() + "' "))
                {
                    using (SqlDataAdapter sdaaa = new SqlDataAdapter())
                    {
                        Cmdd.Connection = con;
                        sdaaa.SelectCommand = Cmdd;
                        using (DataTable dttt = new DataTable())
                        {
                            sdaaa.Fill(dttt);
                            GridView3.DataSource = dttt;
                            GridView3.DataBind();
                        }
                    }
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, EventArgs e)
        {
            int appointment = (GridView2.DataSource as DataTable).Rows.Count;
            label1.Text = appointment.ToString();
        }

        protected void GridView1_RowDataBound(object sender, EventArgs e)
        {
            int rental = (GridView1.DataSource as DataTable).Rows.Count;
            label2.Text = rental.ToString();
        }

        protected void GridView3_RowDataBound(object sender, EventArgs e)
        {
            double total = 0;
            foreach (GridViewRow row in GridView3.Rows)
            {
                string subtotal = ((Label)row.FindControl("total")).Text;
                total += !string.IsNullOrEmpty(subtotal) ? Convert.ToDouble(subtotal) : 0;
            }

            label3.Text = "RM " + total.ToString();
        }

        private void GetChartData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT MONTH(paymentdate) AS Month, YEAR(paymentdate) AS Year,SUM(CAST(total AS decimal)) AS TotalRevenue FROM payment WHERE landlordID='" + Session["ID"].ToString() + "' GROUP BY YEAR(paymentdate), MONTH(paymentdate) ORDER BY YEAR(paymentdate), MONTH(paymentdate)", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            Chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            Chart1.Series["Series1"].XValueMember = "Month";
            Chart1.Series["Series1"].YValueMembers = "TotalRevenue";
            Chart1.DataSource = rdr;
            Chart1.DataBind();
        }

    }
}