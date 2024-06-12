using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace HouseRental
{
    public partial class landlordContract : System.Web.UI.Page
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from people WHERE email='" + Session["email"].ToString() + "';", con);
                int userID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session.Add("ID", userID);

                if (!IsPostBack)
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM appointment LEFT JOIN people ON appointment.studentID=people.ID WHERE rental='1'", con);
                    // table name   
                    SqlDataAdapter d = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    d.Fill(ds);  // fill dataset  
                    DropDownList1.DataTextField = ds.Tables[0].Columns["name"].ToString(); // text field name of table dispalyed in dropdown       
                    DropDownList1.DataValueField = ds.Tables[0].Columns["name"].ToString();
                    // to retrive specific  textfield name   
                    DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    DropDownList1.DataBind();  //binding dropdownlist  

                    SqlCommand comm = new SqlCommand("SELECT * FROM appointment LEFT JOIN room ON appointment.houseID=room.ID WHERE rental='1'", con);
                    // table name   
                    SqlDataAdapter daa = new SqlDataAdapter(comm);
                    DataSet dss = new DataSet();
                    daa.Fill(dss);  // fill dataset  
                    DropDownList2.DataTextField = dss.Tables[0].Columns["hname"].ToString(); // text field name of table dispalyed in dropdown       
                    DropDownList2.DataValueField = dss.Tables[0].Columns["hname"].ToString();
                    // to retrive specific  textfield name   
                    DropDownList2.DataSource = dss.Tables[0];      //assigning datasource to the dropdownlist  
                    DropDownList2.DataBind();  //binding dropdownlist 
                }
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * from people WHERE name='" + Session["name"].ToString() + "';", con);
            int landlordID = Convert.ToInt32(cmd.ExecuteScalar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string name = dt.Rows[0]["name"].ToString();
            string email = dt.Rows[0]["email"].ToString();

            SqlCommand insertCmd = new SqlCommand("SELECT ic from people WHERE name='" + DropDownList1.Text + "'", con);
            SqlDataAdapter daa = new SqlDataAdapter(insertCmd);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);

            string ic = dtt.Rows[0]["ic"].ToString();

            if (checkAddEmptyBox())
            {
                if (checkStudentExists())
                {
                    Response.Write("<script>alert('Student Exists. Please choose other student.');</script>");
                }
                else
                {
                    int contractID = addNewContract(name, ic);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand Cmd = new SqlCommand("SELECT (ID) FROM people WHERE name ='" + DropDownList1.SelectedItem + "';", con);
                    int studentID = Convert.ToInt32(Cmd.ExecuteScalar());

                    Cmd = new SqlCommand("SELECT (rentprice) FROM room WHERE hname ='" + DropDownList2.SelectedItem + "';", con);
                    decimal rentprice = Convert.ToDecimal(Cmd.ExecuteScalar());

                    string insert = "INSERT INTO payment VALUES(@details,@price,@date,@status,@studentID,@paymentdate,@latefee,@total,@landlordID,@contractID)";
                    Cmd = new SqlCommand(insert, con);
                    Cmd.Parameters.AddWithValue("@details", "Deposit");
                    Cmd.Parameters.AddWithValue("@price", TextBox2.Text.Trim());
                    Cmd.Parameters.AddWithValue("@date", TextBox1.Text.Trim());
                    Cmd.Parameters.AddWithValue("@status", "Pending");
                    Cmd.Parameters.AddWithValue("@studentID", studentID);
                    Cmd.Parameters.AddWithValue("@paymentdate", "");
                    Cmd.Parameters.AddWithValue("@latefee", "0");
                    Cmd.Parameters.AddWithValue("@total", TextBox2.Text.Trim());
                    Cmd.Parameters.AddWithValue("@landlordID", landlordID);
                    Cmd.Parameters.AddWithValue("@contractID", contractID);
                    Cmd.ExecuteNonQuery();

                    con.Close();
                    cmd.Dispose();
                    new Global().checkpayment();
                }
            }
        }

        int addNewContract(string landlord_name, string student_ic)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand insertCmd = new SqlCommand("SELECT (ID) FROM people WHERE email='" + Session["email"].ToString() + "';", con);
                int landlordID = Convert.ToInt32(insertCmd.ExecuteScalar());

                string insertQuery = "INSERT INTO contract VALUES(@student_name,@landlord_name,@house_name,@date,@duration,@deposit,@landlordID,@student_ic);select SCOPE_IDENTITY();";
                insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@student_name", DropDownList1.SelectedItem.Text);
                insertCmd.Parameters.AddWithValue("@landlord_name", landlord_name);
                insertCmd.Parameters.AddWithValue("@house_name", DropDownList2.SelectedItem.Text);
                insertCmd.Parameters.AddWithValue("@date", TextBox1.Text.Trim());
                insertCmd.Parameters.AddWithValue("@duration", DropDownList3.SelectedItem.Value);
                insertCmd.Parameters.AddWithValue("@deposit", TextBox2.Text.Trim());
                insertCmd.Parameters.AddWithValue("@landlordID", landlordID);
                insertCmd.Parameters.AddWithValue("@student_ic", student_ic);

                int status = int.Parse(insertCmd.ExecuteScalar().ToString());
                con.Close();
                if (status > 0)
                {
                    Response.Write("<script>alert('Contract added successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

                SqlDataSource1.DataBind();
                GridView2.DataSource = null;
                GridView2.DataSourceID = "SqlDataSource1";
                GridView2.SelectedIndex = -1;
                return status;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return 0;
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[4].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you confirm to delete?');";
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox5.Text = GridView2.SelectedRow.Cells[1].Text;
            TextBox6.Text = GridView2.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView2.SelectedRow.Cells[3].Text;
            ModalPopupExtender1.Show();
            getContractDetails();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE contract SET student_name=@student_name,house_name=@house_name,date=@date,duration=@duration,deposit=@deposit WHERE student_name='" + TextBox5.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@student_name", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@house_name", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@duration", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@deposit", TextBox4.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                if (checkEmptyBox())
                {
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Details updated successfully.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid entry');</script>");
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

        void getContractDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from contract WHERE student_name='" + TextBox5.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox5.Text = dt.Rows[0]["student_name"].ToString();
                TextBox6.Text = dt.Rows[0]["house_name"].ToString();
                TextBox3.Text = dt.Rows[0]["date"].ToString();
                DropDownList4.SelectedValue = dt.Rows[0]["duration"].ToString();
                TextBox4.Text = dt.Rows[0]["deposit"].ToString();
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from contract", con);

                if (TextBox1.Text.Trim() != string.Empty)
                {
                    if (TextBox2.Text.Trim() != string.Empty)
                    {
                        return true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in deposit.');</script>");
                        return false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please fill in effective date.');</script>");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool checkStudentExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from contract where student_name='" + DropDownList1.SelectedItem.Text + "';", con);
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
                if (TextBox3.Text.Trim() != string.Empty)
                {
                    if (TextBox4.Text.Trim() != string.Empty)
                    {
                        return true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Please fill in deposit.');</script>");
                        return false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please fill in effective date.');</script>");
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
            DropDownList1.SelectedValue = "";
            DropDownList2.SelectedValue = "";
            DropDownList3.SelectedValue = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void GenerateInvoicePDF(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM contract LEFT JOIN people ON people.ID = contract.landlordID LEFT JOIN room ON room.hname = contract.house_name WHERE contract.student_name='" + TextBox5.Text.Trim() + "' AND contract.house_name='" + TextBox6.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string landlord_name = dt.Rows[0]["name"].ToString();
            string address = dt.Rows[0]["address"].ToString();
            string landlord_ic = dt.Rows[0]["ic"].ToString();
            string housetype = dt.Rows[0]["housetype"].ToString();
            string rentprice = dt.Rows[0]["rentprice"].ToString();
            string student_ic = dt.Rows[0]["student_ic"].ToString();

            TextBox5.Text = dt.Rows[0]["student_name"].ToString();
            TextBox6.Text = dt.Rows[0]["house_name"].ToString();
            TextBox3.Text = dt.Rows[0]["date"].ToString();
            DropDownList4.SelectedValue = dt.Rows[0]["duration"].ToString();
            TextBox4.Text = dt.Rows[0]["deposit"].ToString();

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<table cellspacing='0' cellpadding='2' style='font-size: 18pt;font-family:Times New Roman'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h1><b>TENANCY AGREEMENT</b><h1><br><br><br><br><br></td></tr>");

                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' margin-left='30%' margin-right='30%' colspan = '2'><h2><h2>");
                    sb.Append(address);
                    sb.Append("<br><br><br><br><br></td></tr>");

                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h2><b>BETWEEN</b><h2></td></tr><br>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'>");
                    sb.Append(landlord_name);
                    sb.Append("<br><br><br><br></td></tr>");

                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h2><b>AND</b><h2></td></tr><br>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'>");
                    sb.Append(TextBox5.Text);
                    sb.Append("<br><br><br><br></td></tr>");

                    sb.Append("</td><td align='center' style='background-color: #18B5F0' colspan = '2'><b>ON </b>");
                    sb.Append(TextBox3.Text);
                    sb.Append("</td></tr>");

                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");

                    //Generate Contract Items Grid.
                    sb.Append("<table border = '1' style='font-size: 12pt;font-family:Times New Roman'>");
                    sb.Append("<tr>");
                    sb.Append("<th width='10%' align='center'><b>No</b></th>");
                    sb.Append("<th align='center'><b>Matters</b></th>");
                    sb.Append("<th align='center'><b>Details</b></th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td align='center'>1.</td>");
                    sb.Append("<td><br>Agreement Date</td>");
                    sb.Append("<br><td><br>");
                    sb.Append(TextBox3.Text);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>2.</td>");
                    sb.Append("<td><br>Landlord<br><br>Name:<br>IC:</td>");
                    sb.Append("<br><td><br>");
                    sb.Append(landlord_name);
                    sb.Append("<br>");
                    sb.Append(landlord_ic);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>3.</td>");
                    sb.Append("<td><br>Tenant<br><br>Name:<br>IC:</td>");
                    sb.Append("<br><td><br>");
                    sb.Append(TextBox5.Text);
                    sb.Append("<br>");
                    sb.Append(student_ic);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>4.</td>");
                    sb.Append("<td><br>Property Address</td>");
                    sb.Append("<br><td><br>");
                    sb.Append(address);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>5.</td>");
                    sb.Append("<td><br>House Type</td>");
                    sb.Append("<br><td><br>");
                    sb.Append(housetype);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>6.</td>");
                    sb.Append("<td><br>Duration of Tenancy</td>");
                    sb.Append("<br><td><br>");
                    sb.Append(DropDownList4.SelectedValue);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>7.</td>");
                    sb.Append("<td><br>Monthly Rental</td>");
                    sb.Append("<br><td><br>RM");
                    sb.Append(rentprice);
                    sb.Append("<br></td>");

                    sb.Append("<td align='center'>8.</td>");
                    sb.Append("<td><br>Deposit</td>");
                    sb.Append("<br><td><br>RM");
                    sb.Append(TextBox4.Text);
                    sb.Append("<br></td>");

                    sb.Append("</tr>");
                    sb.Append("</tr></table>");

                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<table style='font-size: 12pt;font-family:Times New Roman' cellspacing='0' cellpadding='2'>");

                    sb.Append("<tr><td>This agreement was made on ");
                    sb.Append("<b>");
                    sb.Append(TextBox3.Text);
                    sb.Append("</b>");
                    sb.Append(", between ");
                    sb.Append("<b>");
                    sb.Append(landlord_name);
                    sb.Append("</b>");
                    sb.Append(" (from now on referred to as 'Landlord') and ");
                    sb.Append("<b>");
                    sb.Append(TextBox5.Text);
                    sb.Append("</b>");
                    sb.Append(" (from now on referred to as 'Tenant').");
                    sb.Append("<br><br></td></tr>");

                    sb.Append("<tr><td>WHEREAS the Landlord is the registered owner of the house located at ");
                    sb.Append("<b>");
                    sb.Append(address);
                    sb.Append("</b>");
                    sb.Append(" (from now on referred to as the 'Said House').");
                    sb.Append("<br><br></td></tr>");

                    sb.Append("<tr><td>AND WHEREAS the Landlord now agrees to lease, and the Tenant agrees to rent the Said House for ");
                    sb.Append("<b>");
                    sb.Append(DropDownList4.SelectedValue);
                    sb.Append("</b>");
                    sb.Append(", subject to the terms and conditions contained herein.");
                    sb.Append("<br><br></td></tr>");

                    sb.Append("<tr><td style='background-color: #18B5F0' colspan = '2'><b>AGREEMENT BETWEEN LANDLORD AND TENANT:</b><br><br></td></tr>");
                    sb.Append("<td>1.   The Landlord shall hand over the house keys to the Tenant after the Tenant pays the deposit unless agreed upon by both parties.<br><br></td>");
                    sb.Append("<td>2.	If the agreement ends or the Landlord or Tenant terminates it, it is the Tenant's responsibility to immediately hand over the house keys and access card to the Landlord or their representative.<br><br></td>");
                    sb.Append("<td>3.	If the Landlord receives no rental payment on the agreed date as stated in the Second Schedule (4), the deposit will be used to pay the arrears, and the Landlord has the right to terminate this rental agreement immediately unless the Landlord, at his/her discretion, gives additional time for the Tenant to settle the arrears.<br><br></td>");
                    sb.Append("<td>4.	If the Tenant wishes to renew the rental period when the period contained in this agreement ends, the Tenant must give written notice to the Landlord at least two (2) months before the end of the rental period.<br><br></td>");
                    sb.Append("<td>5.	The Landlord has the right not to renew the rental period.<br><br></td>");
                    sb.Append("<td>6.	The Landlord has the right to terminate this rental period immediately if there is a violation of the terms of this agreement. Or when the Landlord wishes to reclaim the House for any purpose by giving written notice to the Tenant no less than two (2) months in advance.<br><br></td>");
                    sb.Append("<td>7.	The Tenant has the right to terminate the rental by giving written notice to the Landlord for at least two (2) months or the deposit will not be refunded.<br><br></td>");
                    sb.Append("<td>8.   During the notice period, the Tenant must pay the monthly rent as usual and cannot use the deposit to pay the monthly rent.<br><br></td>");
                    sb.Append("<td>9.	Termination by the Tenant will not release the Tenant from paying the Landlord any outstanding payments as stated in this agreement.<br><br></td>");
                    sb.Append("<td>10.	Any disputes between the Landlord and Tenant regarding the rental of the House shall be resolved peacefully and amicably. If a resolution cannot be reached, it shall be resolved through arbitration.<br><br></td>");
                    sb.Append("<br><br></tr>");

                    sb.Append("<tr><td>IN WITNESS WHEREOF the parties hereto have hereunto set their hands on the day and year first above written.");
                    sb.Append("<br><br><br><br></td></tr>");

                    sb.Append("<tr><td>..................................</td>");
                    sb.Append("<tr><td>Landlord</td>");
                    sb.Append("<tr><td>Name: ");
                    sb.Append(landlord_name);
                    sb.Append("</td><td> IC No: ");
                    sb.Append(landlord_ic);
                    sb.Append("<br><br><br><br></td></tr>");

                    sb.Append("<tr><td>..................................</td>");
                    sb.Append("<tr><td>Tenant</td>");
                    sb.Append("<tr><td>Name: ");
                    sb.Append(TextBox5.Text);
                    sb.Append("</td><td> IC No: ");
                    sb.Append(student_ic);
                    sb.Append("</td></tr>");

                    sb.Append("</tr></table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Contract_" + TextBox6.Text + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}