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
using System.Drawing;

namespace HouseRental
{
    public partial class studentAppointment : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                int studentID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session.Add("ID", studentID);
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
                TextBox status = e.Row.Cells[5].FindControl("status") as TextBox;
                if (e.Row.Cells[5].Text == "Pending")
                {
                    e.Row.Cells[5].CssClass = "badge badge-pill badge-warning";
                }
                if (e.Row.Cells[5].Text == "Completed")
                {
                    e.Row.Cells[5].CssClass = "badge badge-pill badge-success";
                }
                if (e.Row.Cells[5].Text == "Cancelled")
                {
                    e.Row.Cells[5].CssClass = "badge badge-pill badge-danger";
                }
                if (e.Row.Cells[5].Text == "Upcoming")
                {
                    e.Row.Cells[5].CssClass = "badge badge-pill badge-primary";
                }
                if (e.Row.Cells[5].Text == "Absent")
                {
                    e.Row.Cells[5].CssClass = "badge badge-pill badge-dark";
                }
                if (e.Row.Cells[5].Text == "Attended")
                {
                    e.Row.Cells[5].CssClass = "badge badge-pill badge-info";
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView2.SelectedRow.Cells[1].Text;
            DropDownList1.SelectedValue = GridView2.SelectedRow.Cells[2].Text;
            ModalPopupExtender1.Show();
            getAppointmentDetails();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE appointment SET appointment_date=@appointment_date,slot=@slot WHERE appointment_date='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@appointment_date", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@slot", DropDownList1.SelectedItem.Value);

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
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from appointment LEFT JOIN room ON appointment.houseID = room.ID LEFT JOIN people ON room.userID = people.ID WHERE appointment.appointment_date='" + TextBox1.Text.Trim() + "' AND appointment.slot='" + DropDownList1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["appointment_date"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["slot"].ToString();
                TextBox2.Text = dt.Rows[0]["hname"].ToString();
                TextBox3.Text = dt.Rows[0]["address"].ToString();
                TextBox4.Text = dt.Rows[0]["name"].ToString();
                TextBox5.Text = dt.Rows[0]["contactnum"].ToString();
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
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from appointment WHERE appointment_date='" + TextBox1.Text.Trim() + "' AND slot='" + DropDownList1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox6.Text = dt.Rows[0]["appointment_date"].ToString();
                DropDownList2.SelectedValue = dt.Rows[0]["slot"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Cancel(object sender, EventArgs e)
        {
            try
            {
                if (TextBox11.Text.Trim() != string.Empty)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                    int cancel_user_id = Convert.ToInt32(cmd.ExecuteScalar());

                    string insertQuery = "UPDATE appointment SET status=@status,cancel_user_id=@cancel_user_id,cancel_reason=@cancel_reason WHERE appointment_date='" + TextBox6.Text.Trim() + "'";
                    cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@cancel_user_id", cancel_user_id);
                    cmd.Parameters.AddWithValue("@cancel_reason", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", "Cancelled");

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Write("<script>alert('Appointment cancelled successfully.');</script>");
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
                else
                {
                    Response.Write("<script>alert('Please write cancellation reason.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Confirm(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                int cancel_user_id = Convert.ToInt32(cmd.ExecuteScalar());

                string insertQuery = "UPDATE appointment SET status=@status,rental=@rental WHERE appointment_date='" + TextBox6.Text.Trim() + "'";
                cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@status", "Completed");
                cmd.Parameters.AddWithValue("@rental", 1);
                
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Response.Write("<script>alert('You have confirmed rental successfully.');</script>");
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);
            GridViewRow row = GridView2.Rows[rowIndex];
            TextBox6.Text = (row.FindControl("date") as Label).Text;
            DropDownList2.SelectedValue = (row.FindControl("slot") as Label).Text;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from appointment WHERE appointment_date='" + TextBox6.Text.Trim() + "' AND slot='" + DropDownList2.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string status = dt.Rows[0]["status"].ToString();
            string cancel_user_id = dt.Rows[0]["cancel_user_id"].ToString();
            TextBox11.Text = dt.Rows[0]["cancel_reason"].ToString();

            if (status == "Completed")
            {
                label7.Visible = true;

                label2.Visible = false;
                TextBox11.Visible = false;
                Button2.Visible = false;
                label8.Visible = false;
            }
            else
            {
                if (cancel_user_id == "0")
                {
                    label2.Visible = false;
                    TextBox11.Visible = true;
                    TextBox11.ReadOnly = false;
                    Button2.Visible = true;
                    label7.Visible = false;
                    label8.Visible = true;
                }
                else
                {
                    label2.Visible = true;
                    TextBox11.Visible = true;
                    label7.Visible = false;
                    TextBox11.ReadOnly = true;
                    Button2.Visible = false;
                    label8.Visible = true;
                }
            }
            
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);
            GridViewRow row = GridView2.Rows[rowIndex];
            TextBox6.Text = (row.FindControl("date") as Label).Text;
            DropDownList2.SelectedValue = (row.FindControl("slot") as Label).Text;
            
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from appointment WHERE appointment_date='" + TextBox6.Text.Trim() + "' AND slot='" + DropDownList2.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string rental = dt.Rows[0]["rental"].ToString();
            string status = dt.Rows[0]["status"].ToString();

            if (status == "Absent" || status == "Cancelled")
            {
                label5.Visible = true;

                label1.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                Button1.Visible = false;
                label9.Visible = false;
            }
            else if((status == "Completed"))
            {
                label4.Visible = true;

                Button1.Visible = false;
                label1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label9.Visible = false;
            }
            else if ((status == "Upcoming"))
            {
                label9.Visible = true;

                label1.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                Button1.Visible = false;
            }
            else if ((status == "Pending"))
            {
                label6.Visible = true;

                label1.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                Button1.Visible = false;
            }
            else
            {
                label1.Visible = true;
                Button1.Visible = true;

                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label9.Visible = false;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openCModal();", true);
        }
    }
}