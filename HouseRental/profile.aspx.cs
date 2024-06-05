using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + Session["email"].ToString() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DropDownList2.Text = dt.Rows[0]["usertype"].ToString().Trim();

                    if (dt.Rows[0]["usertype"].ToString().Trim() == "Student")
                    {
                        FileUpload1.Visible = true;
                        Label2.Visible = true;
                        Label3.Visible = true;
                        Label7.Visible = true;
                        imgPhoto.Visible = true;
                    }
                    else
                    {
                        FileUpload1.Visible = false;
                        Label2.Visible = false;
                        Label3.Visible = false;
                        Label7.Visible = false;
                        imgPhoto.Visible = false;
                    }
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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["image"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE people SET name=@name, email=@email, contactnum=@contactnum, dateofbirth=@dateofbirth, gender=@gender, usertype=@usertype, ic=@ic WHERE email='" + Session["email"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@ic", TextBox5.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (FileUpload1.HasFile)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    }
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand insertCmd = new SqlCommand("SELECT (ID) FROM people WHERE email='" + Session["email"].ToString() + "';", con);
                    int userID = Convert.ToInt32(insertCmd.ExecuteScalar());

                    string insertUpload = "UPDATE proof SET proof=@proof, userID=@userID WHERE userID=@userID";
                    insertCmd = new SqlCommand(insertUpload, con);
                    insertCmd.Parameters.AddWithValue("@proof", bytes);
                    insertCmd.Parameters.AddWithValue("@userID", userID);
                    int exe = insertCmd.ExecuteNonQuery();
                    if (exe < 1)
                    {
                        string insertNew = "INSERT INTO proof (proof, userID) VALUES (@proof, @userID)";
                        insertCmd = new SqlCommand(insertNew, con);
                        insertCmd.Parameters.AddWithValue("@proof", bytes);
                        insertCmd.Parameters.AddWithValue("@userID", userID);
                        insertCmd.ExecuteNonQuery();
                        con.Close();
                    }
                    con.Close();
                }

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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from people LEFT JOIN proof ON people.ID = proof.userID where people.email='" + Session["email"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["name"].ToString();
                TextBox2.Text = dt.Rows[0]["email"].ToString();
                TextBox3.Text = dt.Rows[0]["contactnum"].ToString();
                TextBox4.Text = dt.Rows[0]["dateofbirth"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["gender"].ToString().Trim();
                DropDownList2.SelectedValue = dt.Rows[0]["usertype"].ToString().Trim();
                TextBox5.Text = dt.Rows[0]["ic"].ToString();

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
                byte[] bytes = (byte[])dt.Rows[0]["proof"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                imgPhoto.ImageUrl = "data:image/png;base64," + base64String;

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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
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

        protected void changepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword.aspx");
        }
    }
}