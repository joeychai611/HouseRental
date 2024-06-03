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
    public partial class landlordhouse : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

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
                int userID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session.Add("ID", userID);
            }
        }

<<<<<<< HEAD

        private DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

=======
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["image"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
<<<<<<< HEAD
=======
            
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAddEmptyBox())
            {
                addNewHouse();
            }
        }

        void addNewHouse()
        {
            try
            {
                string acc = "";
                if (CheckBox1.Checked)
                {
                    acc += CheckBox1.Text;
                }
                if (CheckBox2.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox2.Text;
                    }
                    else
                    {
                        acc += CheckBox2.Text;
                    }
                }
                if (CheckBox3.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox3.Text;
                    }
                    else
                    {
                        acc += CheckBox3.Text;
                    }
                }
                if (CheckBox4.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox4.Text;
                    }
                    else
                    {
                        acc += CheckBox4.Text;
                    }
                }
                if (CheckBox5.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox5.Text;
                    }
                    else
                    {
                        acc += CheckBox5.Text;
                    }
                }
                if (CheckBox6.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox6.Text;
                    }
                    else
                    {
                        acc += CheckBox6.Text;
                    }
                }
                if (CheckBox7.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox7.Text;
                    }
                    else
                    {
                        acc += CheckBox7.Text;
                    }
                }
                if (CheckBox8.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox8.Text;
                    }
                    else
                    {
                        acc += CheckBox8.Text;
                    }
                }
                if (CheckBox9.Checked)
                {
                    if (acc != "")
                    {
                        acc += ", ";
                        acc += CheckBox9.Text;
                    }
                    else
                    {
                        acc += CheckBox9.Text;
                    }
                }

                string duration = "";
                if (CheckBox10.Checked)
                {
                    duration = CheckBox10.Text;
                    if (CheckBox11.Checked)
                    {
                        duration += ", " + CheckBox11.Text;
                    }
                }
                else if (CheckBox11.Checked)
                {
                    duration = CheckBox11.Text;
                }

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(fuUpload.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(fuUpload.PostedFile.ContentLength);
                }

                SqlCommand insertCmd = new SqlCommand("SELECT (ID) FROM people WHERE email='" + Session["email"].ToString() + "';", con);
                int userID = Convert.ToInt32(insertCmd.ExecuteScalar());

                string insertQuery = "INSERT INTO room VALUES(@hname,@housetype,@address,@postcode,@city,@description,@accommodation,@rentprice,@duration,@status,@image,@userID)";
                insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@hname", TextBox1.Text.Trim());
                insertCmd.Parameters.AddWithValue("@housetype", DropDownList1.SelectedItem.Value);
<<<<<<< HEAD

                insertCmd.Parameters.AddWithValue("@address", txtPlaces.Text.Trim());
=======
                insertCmd.Parameters.AddWithValue("@address", TextBox2.Text.Trim());
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
                insertCmd.Parameters.AddWithValue("@postcode", TextBox3.Text.Trim());
                insertCmd.Parameters.AddWithValue("@city", TextBox4.Text.Trim());
                insertCmd.Parameters.AddWithValue("@description", TextBox5.Text.Trim());
                insertCmd.Parameters.AddWithValue("@accommodation", acc);
                insertCmd.Parameters.AddWithValue("@rentprice", TextBox6.Text.Trim());
                insertCmd.Parameters.AddWithValue("@duration", duration);
                insertCmd.Parameters.AddWithValue("@status", "Available");
                insertCmd.Parameters.AddWithValue("@image", bytes);
                insertCmd.Parameters.AddWithValue("@userID", userID);

                int status = insertCmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Response.Write("<script>alert('House added successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }
                con.Close();
                clearForm();
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[5].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you confirm to delete?');";
                }
<<<<<<< HEAD

                TextBox status = e.Row.Cells[4].FindControl("status") as TextBox;
                if (e.Row.Cells[4].Text == "Unavailable")
                {
                    e.Row.Cells[4].CssClass = "badge badge-pill badge-warning";
                }
                if (e.Row.Cells[4].Text == "Available")
                {
                    e.Row.Cells[4].CssClass = "badge badge-pill badge-success";
                }

=======
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
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
<<<<<<< HEAD

=======
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                byte[] bytes;
                using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                }

                SqlCommand cmd = new SqlCommand("UPDATE room SET hname=@hname,housetype=@housetype,address=@address,postcode=@postcode,city=@city,description=@description,accommodation=@accommodation,rentprice=@rentprice,duration=@duration,status=@status,image=@image WHERE hname='" + TextBox7.Text + "'", con);

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
                cmd.Parameters.AddWithValue("@image", bytes);

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

<<<<<<< HEAD
                SqlCommand cmd = new SqlCommand("SELECT * from room LEFT JOIN people ON people.ID = room.userID WHERE room.hname='" + TextBox7.Text.Trim() + "'", con);

=======
                SqlCommand cmd = new SqlCommand("SELECT * from room LEFT JOIN people ON people.ID = room.userID where room.hname='" + TextBox7.Text.Trim() + "'", con);
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

<<<<<<< HEAD
=======
                TextBox13.Text = dt.Rows[0]["name"].ToString();
                TextBox14.Text = dt.Rows[0]["email"].ToString();
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
                TextBox7.Text = dt.Rows[0]["hname"].ToString();
                DropDownList2.SelectedValue = dt.Rows[0]["housetype"].ToString();
                TextBox8.Text = dt.Rows[0]["address"].ToString();
                TextBox9.Text = dt.Rows[0]["postcode"].ToString();
                TextBox10.Text = dt.Rows[0]["city"].ToString();
                TextBox11.Text = dt.Rows[0]["description"].ToString();
                byte[] bytes = (byte[])dt.Rows[0]["image"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                imgPhoto.ImageUrl = "data:image/png;base64," + base64String;

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

        bool checkAddEmptyBox()
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
<<<<<<< HEAD
                    if (txtPlaces.Text.Trim() != string.Empty)
=======
                    if (TextBox2.Text.Trim() != string.Empty)
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
                    {
                        if (TextBox3.Text.Trim() != string.Empty)
                        {
                            if (TextBox4.Text.Trim() != string.Empty)
                            {
                                if (TextBox6.Text.Trim() != string.Empty)
                                {
                                    if ((CheckBox10.Checked == false) && (CheckBox11.Checked == false))
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
                                    if ((CheckBox21.Checked == false) && (CheckBox22.Checked == false))
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

        void clearForm()
        {
            TextBox1.Text = "";
            DropDownList1.SelectedValue = "Apartment";
<<<<<<< HEAD
            txtPlaces.Text = "";

=======
            TextBox2.Text = "";
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
            CheckBox6.Checked = false;
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;
            CheckBox9.Checked = false;
            TextBox6.Text = "";
            CheckBox10.Checked = false;
            CheckBox11.Checked = false;
        }
    }
}