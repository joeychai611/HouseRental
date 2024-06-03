using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
=======
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class house1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblName.Text = HttpUtility.UrlDecode(Request.QueryString["hname"]);
                lblHousetype.Text = HttpUtility.UrlDecode(Request.QueryString["housetype"]);
                lblHousetype.Attributes.Add("class", "badge badge-pill badge-info");
                lblAddress.Text = HttpUtility.UrlDecode(Request.QueryString["address"]);
                lblPostcode.Text = HttpUtility.UrlDecode(Request.QueryString["postcode"]);
                lblCity.Text = HttpUtility.UrlDecode(Request.QueryString["city"]);
                lblDescription.Text = HttpUtility.UrlDecode(Request.QueryString["description"]);
                lblAccommodation.Text = HttpUtility.UrlDecode(Request.QueryString["accommodation"]);
                lblRentprice.Text = HttpUtility.UrlDecode(Request.QueryString["rentprice"]);
                lblRentprice.Attributes["style"] = "color:black; font-weight:bold;";
                lblDuration.Text = HttpUtility.UrlDecode(Request.QueryString["duration"]);
                lblStatus.Text = HttpUtility.UrlDecode(Request.QueryString["status"]);
                if (lblStatus.Text == "Available")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-success");

                }
                else if (lblStatus.Text == "Unavailable")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
<<<<<<< HEAD

            }

            if (Session["email"] == null || string.IsNullOrEmpty(Session["email"].ToString()))
            {
                btnShowPopup.Visible = false;
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows[0]["usertype"].ToString().Trim() == "Student")
                {
                    btnShowPopup.Visible = true;
                    getAppointmentDetails();
                }
                else
                {
                    btnShowPopup.Visible = false;
                }
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkEmptyBox())
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from room WHERE hname='" + lblName.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string ID = dt.Rows[0]["ID"].ToString();
                string userID = dt.Rows[0]["userID"].ToString();
                addNewAppointment(ID, userID);
            }
        }

        void addNewAppointment(string houseID, string landlordID)
        {
            try
            {
                if (Session["email"] == null || string.IsNullOrEmpty(Session["email"].ToString()))
                {
                    Response.Write("<script>alert('Please login to make appointment.');</script>");
                    Response.Redirect("login.aspx");
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

                    /*SqlCommand cmd = new SqlCommand("SELECT * from appointment WHERE appointment_date='" + TextBox1.Text.Trim() + "' AND slot='" + DropDownList1.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string sstatus = dt.Rows[0]["status"].ToString();*/

                    //DateTime endDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

                    // compare both dates
                    /*if (Convert.ToDateTime(TextBox1.Text.Trim()) < endDate)
                    {
                        Response.Write("<script>alert('The selected appointment date must be later than today's date.');</script>");
                    }
                    else
                    {*/
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand insertCmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                    int studentID = Convert.ToInt32(insertCmd.ExecuteScalar());

                    string insertQuery = "INSERT INTO appointment VALUES(@appointment_date,@slot,@status,@cancel_user_id,@cancel_reason,@houseID,@landlordID,@studentID,@rental)";
                    insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@appointment_date", TextBox1.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@slot", DropDownList1.SelectedItem.Value);
                    insertCmd.Parameters.AddWithValue("@status", "Pending");
                    insertCmd.Parameters.AddWithValue("@cancel_user_id", 0);
                    insertCmd.Parameters.AddWithValue("@cancel_reason", "");
                    insertCmd.Parameters.AddWithValue("@houseID", houseID);
                    insertCmd.Parameters.AddWithValue("@landlordID", landlordID);
                    insertCmd.Parameters.AddWithValue("@studentID", studentID);
                    insertCmd.Parameters.AddWithValue("@rental", 0);

                    int status = insertCmd.ExecuteNonQuery();

                    if (status > 0)
                    {
                        Response.Write("<script>alert('Appointment added successfully.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invaid entry');</script>");
                    }
                    con.Close();
                    clearForm();
                    //}
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

                SqlCommand cmd = new SqlCommand("SELECT * from room LEFT JOIN people ON room.userID = people.ID WHERE room.hname='" + lblName.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lblLandlord.Text = dt.Rows[0]["name"].ToString();
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

                SqlCommand cmd = new SqlCommand("SELECT * from appointment", con);
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

        void clearForm()
        {
            TextBox1.Text = "";
            DropDownList1.SelectedValue = "9.00AM - 10.00AM";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
=======
            }

>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
        }
    }
}