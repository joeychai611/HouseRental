using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //register button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('testing');</script>");
            if (checkEmptyBox())
            {
                if (checkUserExists())
                {
                    Response.Write("<script>alert('Email Exists. Login now or try another email.');</script>");
                }
                else
                {
                    registerNewUser();
                }
            }
                    
        }

        //user defined method
        bool checkEmptyBox()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from consumer where email='" + TextBox3.Text.Trim() + "' AND password='" + TextBox5.Text.Trim() + "' AND confirmpassword='" + TextBox6.Text.Trim() + "';", con);
                if (TextBox3.Text.Trim() != string.Empty)
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

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from consumer where email='"+TextBox3.Text.Trim()+"';", con);
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

        void registerNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string insertQuery = "INSERT INTO consumer VALUES(@fname,@lname,@email,@usertype,@gender,@dateofbirth,@password,@confirmpassword,@accountstatus)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@fname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@usertype", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@gender", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@confirmpassword", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@accountstatus", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Register Successful. Login now.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        
    }
}