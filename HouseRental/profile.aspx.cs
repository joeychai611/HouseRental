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
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
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
                    }
                    else
                    {
                        FileUpload1.Visible = false;
                        Label2.Visible = false;
                    }
                    getUserData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                        GridView1.PreRender += new EventHandler(GridView1_PreRender);
                        bind();
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
                SqlCommand cmd = new SqlCommand("UPDATE people SET name=@name, email=@email, contactnum=@contactnum, dateofbirth=@dateofbirth, gender=@gender, usertype=@usertype WHERE email='" + Session["email"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                
                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (FileUpload1.HasFile)
                {
                    byte[] myphoto = FileUpload1.FileBytes;
                    GridViewRow row = GridView1.SelectedRow;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand insertCmd = new SqlCommand("SELECT (ID) FROM people WHERE email='" + Session["email"].ToString() + "';", con);
                    int userID = Convert.ToInt32(insertCmd.ExecuteScalar());

                    string insertUpload = "UPDATE proof SET proof=@proof, userID=@userID WHERE userID=@userID";
                    insertCmd = new SqlCommand(insertUpload, con);
                    insertCmd.Parameters.AddWithValue("@proof", myphoto);
                    insertCmd.Parameters.AddWithValue("@userID", userID);
                    int exe = insertCmd.ExecuteNonQuery();
                    if (exe < 1)
                    {
                        string insertNew = "INSERT INTO proof (proof, userID) VALUES (@proof, @userID)";
                        insertCmd = new SqlCommand(insertNew, con);
                        insertCmd.Parameters.AddWithValue("@proof", myphoto);
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

        protected void changepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword.aspx");
        }

        public void bind()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
            con.Open();
            
            string query = "select * from proof";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            con.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}