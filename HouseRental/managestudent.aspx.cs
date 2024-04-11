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
    public partial class managestudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Proof/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new ListItem(fileName, "~/Proof/" + fileName));
                }
                rptFiles.DataSource = files;
                rptFiles.DataBind();
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
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView2.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView2.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView2.SelectedRow.Cells[3].Text;
            DropDownList3.SelectedValue = GridView2.SelectedRow.Cells[4].Text;
            ModalPopupExtender1.Show();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
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
                cmd.Parameters.AddWithValue("@accountstatus", DropDownList3.SelectedItem.Value);

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

        protected void View(object sender, EventArgs e)
        {
            imgFile.ImageUrl = string.Empty;
            ltEmbed.Text = string.Empty;
            string fileName = (sender as LinkButton).CommandArgument;
            string extension = Path.GetExtension(fileName);
            switch (extension.ToLower())
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".gif":
                    imgFile.ImageUrl = "~/Proof/" + fileName;
                    break;
                case ".pdf":
                    string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"300px\" height=\"200px\">";
                    embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                    embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                    embed += "</object>";
                    ltEmbed.Text = string.Format(embed, ResolveUrl("~/Proof/" + fileName));
                    break;
                default:
                    break;
            }
            imgFile.Visible = !string.IsNullOrEmpty(imgFile.ImageUrl);
            ltEmbed.Visible = !string.IsNullOrEmpty(ltEmbed.Text);
        }
    }
}