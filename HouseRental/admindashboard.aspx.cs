using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

namespace HouseRental
{
    public partial class admindashboard : System.Web.UI.Page
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

                if (!this.IsPostBack)
                {
                    this.BindGrid();
                }
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM people WHERE usertype ='Student'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                label1.Text = "0";
                            }
                            else
                            {
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                            }
                        }
                    }
                }

                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM people WHERE usertype ='Landlord'"))
                {
                    using (SqlDataAdapter sdaa = new SqlDataAdapter())
                    {
                        Cmd.Connection = con;
                        sdaa.SelectCommand = Cmd;
                        using (DataTable dtt = new DataTable())
                        {
                            sdaa.Fill(dtt);
                            if (dtt.Rows.Count == 0)
                            {
                                label2.Text = "0";
                            }
                            else
                            {
                                GridView1.DataSource = dtt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

                using (SqlCommand Cmdd = new SqlCommand("SELECT * FROM room"))
                {
                    using (SqlDataAdapter sdaaa = new SqlDataAdapter())
                    {
                        Cmdd.Connection = con;
                        sdaaa.SelectCommand = Cmdd;
                        using (DataTable dttt = new DataTable())
                        {
                            sdaaa.Fill(dttt);
                            if (dttt.Rows.Count == 0)
                            {
                                label3.Text = "0";
                            }
                            else
                            {
                                GridView3.DataSource = dttt;
                                GridView3.DataBind();
                            }
                        }
                    }
                }

                using (SqlCommand Cmddd = new SqlCommand("SELECT * FROM appointment WHERE rental =1"))
                {
                    using (SqlDataAdapter sdaaaa = new SqlDataAdapter())
                    {
                        Cmddd.Connection = con;
                        sdaaaa.SelectCommand = Cmddd;
                        using (DataTable dtttt = new DataTable())
                        {
                            sdaaaa.Fill(dtttt);
                            if (dtttt.Rows.Count == 0)
                            {
                                label4.Text = "0";
                            }
                            else
                            {
                                GridView4.DataSource = dtttt;
                                GridView4.DataBind();
                            }
                        }
                    }
                }

                using (SqlCommand CCmddd = new SqlCommand("SELECT * FROM people WHERE accountstatus ='Pending'"))
                {
                    using (SqlDataAdapter ssdaaaa = new SqlDataAdapter())
                    {
                        CCmddd.Connection = con;
                        ssdaaaa.SelectCommand = CCmddd;
                        using (DataTable ddtttt = new DataTable())
                        {
                            ssdaaaa.Fill(ddtttt);
                            if (ddtttt.Rows.Count == 0)
                            {
                                label5.Text = "0";
                            }
                            else
                            {
                                GridView5.DataSource = ddtttt;
                                GridView5.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, EventArgs e)
        {
            int student = (GridView2.DataSource as DataTable).Rows.Count;
            label1.Text = student.ToString();
        }

        protected void GridView1_RowDataBound(object sender, EventArgs e)
        {
            int landlord = (GridView1.DataSource as DataTable).Rows.Count;
            label2.Text = landlord.ToString();
        }

        protected void GridView3_RowDataBound(object sender, EventArgs e)
        {
            int house = (GridView3.DataSource as DataTable).Rows.Count;
            label3.Text = house.ToString();
        }

        protected void GridView4_RowDataBound(object sender, EventArgs e)
        {
            int rental = (GridView4.DataSource as DataTable).Rows.Count;
            label4.Text = rental.ToString();
        }

        protected void GridView5_RowDataBound(object sender, EventArgs e)
        {
            int verify = (GridView5.DataSource as DataTable).Rows.Count;
            label5.Text = verify.ToString();
        }

        private DataTable GetData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from appointment LEFT JOIN room ON appointment.houseID = room.ID LEFT JOIN people ON appointment.studentID = people.ID WHERE appointment.status='Upcoming'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                dt.Rows[0]["appointment_date"].ToString();
                dt.Rows[0]["hname"].ToString();
            }
            return dt;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DataTable dt = GetData();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["appointment_date"]))
                {
                    e.Cell.Controls.Add(new Label { Text = "<br/>" });
                    e.Cell.Controls.Add(new Label { Text = row["hname"].ToString() });
                    e.Cell.ForeColor = Color.White;
                    e.Cell.BackColor = Color.DarkBlue;
                }
            }
        }
    }
}