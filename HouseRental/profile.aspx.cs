using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["email"] == null || string.IsNullOrEmpty(Session["email"].ToString()))
                {
                    Response.Write("<script>alert('Session expired, login again.');</script>");
                    Response.Redirect("login.aspx");
                }
                else
                {
                    getUserData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session expired, login again.');</script>");
                Response.Redirect("login.aspx");
            }
        }
        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["email"] == null || string.IsNullOrEmpty(Session["email"].ToString()))
            {
                Response.Write("<script>alert('Session expired, login again.');</script>");
                Response.Redirect("login.aspx");
            }
            else
            {
                updateUserPersonalDetails();
            }
        }

        void updateUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE people SET name=@name, email=@email, contactnum=@contactnum, dateofbirth=@dateofbirth, gender=@gender, usertype=@usertype,accountstatus=@accountstatus WHERE email='" + Session["email"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@accountstatus", "Pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Details updated successfully.');</script>");
                    getUserPersonalDetails();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getUserPersonalDetails()
        {
            try
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

                TextBox1.Text = dt.Rows[0]["name"].ToString();
                TextBox2.Text = dt.Rows[0]["email"].ToString();
                TextBox3.Text = dt.Rows[0]["contactnum"].ToString();
                TextBox4.Text = dt.Rows[0]["dateofbirth"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["gender"].ToString().Trim();
                DropDownList2.SelectedValue = dt.Rows[0]["usertype"].ToString().Trim();

                Label1.Text = dt.Rows[0]["accountstatus"].ToString().Trim();

                if (dt.Rows[0]["accountstatus"].ToString().Trim() == "Active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["accountstatus"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["accountstatus"].ToString().Trim() == "Deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getUserData()
        {
            try
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
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //proof
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (file.HasFile)
            {
                string ext = System.IO.Path.GetExtension(file.FileName);

                ext = ext.ToLower();

                if(ext == ".png" || ext == "jpg" || ext == "jpeg")
                {
                    file.SaveAs(Server.MapPath("~/MatricCard/" + file.FileName));

                    lblmsg.Text = "File Uploaded.";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblmsg.Text = "Please select image file only.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblmsg.Text = "Please select a file.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}