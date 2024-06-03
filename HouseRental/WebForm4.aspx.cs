using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView2.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView2.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView2.SelectedRow.Cells[3].Text;
            TextBox4.Text = GridView2.SelectedRow.Cells[4].Text;
            DropDownList1.SelectedValue = GridView2.SelectedRow.Cells[5].Text;
            ModalPopupExtender1.Show();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE people SET name=@name, email=@email, contactnum=@contactnum, dateofbirth=@dateofbirth, gender=@gender, usertype=@usertype,accountstatus=@accountstatus WHERE email='" + TextBox2.Text + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@accountstatus", "Pending");

                int result = cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}