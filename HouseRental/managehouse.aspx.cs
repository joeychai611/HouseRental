using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[6].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you confirm to delete?');";
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox7.Text = GridView2.SelectedRow.Cells[1].Text;
            DropDownList2.SelectedValue = GridView2.SelectedRow.Cells[2].Text;
            TextBox12.Text = GridView2.SelectedRow.Cells[3].Text;
            ModalPopupExtender1.Show();
            getHousePersonalDetails();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                string acc = "";
                if (CheckBox12.Checked)
                {
                    acc += CheckBox12.Text;
                }
                if (CheckBox13.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox13.Text;
                    }
                    else
                    {
                        acc += CheckBox13.Text;
                    }
                }
                if (CheckBox14.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox14.Text;
                    }
                    else
                    {
                        acc += CheckBox14.Text;
                    }
                }
                if (CheckBox15.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox15.Text;
                    }
                    else
                    {
                        acc += CheckBox15.Text;
                    }
                }
                if (CheckBox16.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox16.Text;
                    }
                    else
                    {
                        acc += CheckBox16.Text;
                    }
                }
                if (CheckBox17.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox17.Text;
                    }
                    else
                    {
                        acc += CheckBox17.Text;
                    }
                }
                if (CheckBox18.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox18.Text;
                    }
                    else
                    {
                        acc += CheckBox18.Text;
                    }
                }
                if (CheckBox19.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox19.Text;
                    }
                    else
                    {
                        acc += CheckBox19.Text;
                    }
                }
                if (CheckBox20.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox20.Text;
                    }
                    else
                    {
                        acc += CheckBox20.Text;
                    }
                }

                string duration = "";
                if (CheckBox21.Checked)
                {
                    duration = CheckBox21.Text;
                    if (CheckBox22.Checked)
                    {
                        duration += ", " + CheckBox22.Text;
                    }
                }
                else if (CheckBox22.Checked)
                {
                    duration = CheckBox22.Text;
                }
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE room SET hname=@hname,housetype=@housetype,address=@address,postcode=@postcode,city=@city,description=@description,accommodation=@accommodation,rentprice=@rentprice,duration=@duration,status=@status WHERE hname='" + TextBox7.Text + "'", con);

                cmd.Parameters.AddWithValue("@hname", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@housetype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@postcode", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@accommodation", acc);
                cmd.Parameters.AddWithValue("@rentprice", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@status", "Available");

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

        void getHousePersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from room LEFT JOIN people ON people.ID = room.userID where room.hname='" + TextBox7.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["name"].ToString();
                TextBox2.Text = dt.Rows[0]["email"].ToString();
                TextBox7.Text = dt.Rows[0]["hname"].ToString();
                DropDownList2.SelectedValue = dt.Rows[0]["housetype"].ToString();
                TextBox8.Text = dt.Rows[0]["address"].ToString();
                TextBox9.Text = dt.Rows[0]["postcode"].ToString();
                TextBox10.Text = dt.Rows[0]["city"].ToString();
                TextBox11.Text = dt.Rows[0]["description"].ToString();
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox12.Text))
                {
                    CheckBox12.Checked = true;
                }
                else
                {
                    CheckBox12.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox13.Text))
                {
                    CheckBox13.Checked = true;
                }
                else
                {
                    CheckBox13.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox14.Text))
                {
                    CheckBox14.Checked = true;
                }
                else
                {
                    CheckBox14.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox15.Text))
                {
                    CheckBox15.Checked = true;
                }
                else
                {
                    CheckBox15.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox16.Text))
                {
                    CheckBox16.Checked = true;
                }
                else
                {
                    CheckBox16.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox17.Text))
                {
                    CheckBox17.Checked = true;
                }
                else
                {
                    CheckBox17.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox18.Text))
                {
                    CheckBox18.Checked = true;
                }
                else
                {
                    CheckBox18.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox19.Text))
                {
                    CheckBox19.Checked = true;
                }
                else
                {
                    CheckBox19.Checked = false;
                }
                if (dt.Rows[0]["accommodation"].ToString().Contains(CheckBox20.Text))
                {
                    CheckBox20.Checked = true;
                }
                else
                {
                    CheckBox20.Checked = false;
                }
                TextBox12.Text = dt.Rows[0]["rentprice"].ToString();
                if (dt.Rows[0]["duration"].ToString().Contains(CheckBox21.Text))
                {
                    CheckBox21.Checked = true;
                }
                else
                {
                    CheckBox21.Checked = false;
                }
                if (dt.Rows[0]["duration"].ToString().Contains(CheckBox22.Text))
                {
                    CheckBox22.Checked = true;
                }
                else
                {
                    CheckBox22.Checked = false;
                }
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
                if (TextBox7.Text.Trim() != string.Empty)
                {
                    if (TextBox8.Text.Trim() != string.Empty)
                    {
                        if (TextBox9.Text.Trim() != string.Empty)
                        {
                            if (TextBox10.Text.Trim() != string.Empty)
                            {
                                if (TextBox12.Text.Trim() != string.Empty)
                                {
                                    if ((CheckBox21.Checked==false) && (CheckBox22.Checked == false))
                                    {
                                        Response.Write("<script>alert('Please check duration at least one.');</script>");
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Please fill in monthly rent price.');</script>");
                                    return false;
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Please fill in city.');</script>");
                                return false;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill in postcode.');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in address.');</script>");
                        return false;
                    }

                }
                else
                {
                    Response.Write("<script>alert('Please fill in house name.');</script>");
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