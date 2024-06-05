using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[5].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you confirm to delete?');";
                }
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }

        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkEmptyBox())
            {
                if (checkUserExists())
                {
                    Response.Write("<script>alert('This email already exist. Add other email.');</script>");
                }
                else
                {
                    addNewStudent();
                }
            }
        }

        void addNewStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string insertQuery = "INSERT INTO people VALUES(@name,@email,@contactnum,@dateofbirth,@gender,@usertype,@password,@confirmpassword,@accountstatus)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@password", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@confirmpassword", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@accountstatus", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student added successfully.');</script>");
                clearForm();
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        bool checkEmptyBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from people where email='" + TextBox2.Text.Trim() + "' AND password='" + TextBox5.Text.Trim() + "' AND confirmpassword='" + TextBox6.Text.Trim() + "';", con);
                if (TextBox2.Text.Trim() != string.Empty)
                {
                    if (TextBox5.Text.Trim() != string.Empty)
                    {
                        if (TextBox6.Text.Trim() != string.Empty)
                        {
                            if (TextBox5.Text.Trim() == TextBox6.Text.Trim())
                            {
                                return true;
                            }
                            else
                            {
                                Response.Write("<script>alert('Please fill in same password.');</script>");
                                return false;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill in confirm password.');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in password.');</script>");
                        return false;
                    }

                }
                else
                {
                    Response.Write("<script>alert('Please fill in email.');</script>");
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
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.SelectedValue = "Male";
            DropDownList2.SelectedValue = "Student";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }
    }
}