using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class landlordAppointment : System.Web.UI.Page
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
                SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                int landlordID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session.Add("ID", landlordID);
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox status = e.Row.Cells[3].FindControl("status") as TextBox;
                if (e.Row.Cells[3].Text == "Pending")
                {
                    e.Row.Cells[3].CssClass = "badge badge-pill badge-warning";
                }
                if (e.Row.Cells[3].Text == "Upcoming")
                {
                    e.Row.Cells[3].CssClass = "badge badge-pill badge-primary";
                }
                if (e.Row.Cells[3].Text == "Cancelled")
                {
                    e.Row.Cells[3].CssClass = "badge badge-pill badge-danger";
                }
                if (e.Row.Cells[3].Text == "Absent")
                {
                    e.Row.Cells[3].CssClass = "badge badge-pill badge-dark";
                }
                if (e.Row.Cells[3].Text == "Completed")
                {
                    e.Row.Cells[3].CssClass = "badge badge-pill badge-success";
                }
                if (e.Row.Cells[3].Text == "Attended")
                {
                    e.Row.Cells[3].CssClass = "badge badge-pill badge-info";
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView2.SelectedRow.Cells[1].Text;
            DropDownList1.SelectedValue = GridView2.SelectedRow.Cells[2].Text;
            DropDownList2.SelectedValue = GridView2.SelectedRow.Cells[3].Text;
            if (GridView2.SelectedRow.Cells[3].Text == "Cancelled")
            {
                TextBox6.Visible = true;
                label1.Visible = true;
                DropDownList2.Visible = false;
                label2.Visible = false;
            }
            else
            {
                TextBox6.Visible = false;
                label1.Visible = false;
                DropDownList2.Visible = true;
                label2.Visible = true;
            }
            ModalPopupExtender1.Show();
            getAppointmentDetails();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE appointment SET status=@status WHERE appointment_date='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@status", DropDownList2.SelectedItem.Value);

                int result = cmd.ExecuteNonQuery();
                if (checkEmptyBox())
                {
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Details updated successfully.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invaid entry');</script>");
                    }
                    SqlDataSource1.DataBind();
                    GridView2.DataSource = null;
                    GridView2.DataSourceID = "SqlDataSource1";
                    GridView2.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getAppointmentDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from appointment LEFT JOIN room ON appointment.houseID = room.ID LEFT JOIN people ON appointment.studentID = people.ID WHERE appointment.appointment_date='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["appointment_date"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["slot"].ToString();
                TextBox2.Text = dt.Rows[0]["hname"].ToString();
                TextBox3.Text = dt.Rows[0]["address"].ToString();
                TextBox4.Text = dt.Rows[0]["name"].ToString();
                TextBox5.Text = dt.Rows[0]["contactnum"].ToString();
                TextBox6.Text = dt.Rows[0]["cancel_reason"].ToString();
                DropDownList2.SelectedValue = dt.Rows[0]["status"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        bool checkEmptyBox()
        {
            try
            {
                SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from room", con);
                if (TextBox1.Text.Trim() != string.Empty)
                {
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('Please choose appointment date.');</script>");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
    }
}