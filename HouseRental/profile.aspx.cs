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
                    getUserData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
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
                /*
                if (FileUpload1.HasFile)
                {
                    int fileLen;
                    // Get the length of the file.
                    fileLen = FileUpload1.PostedFile.ContentLength;
                    byte[] input = new byte[fileLen - 1];
                    input = FileUpload1.FileBytes;

                    byte[] fileBytes = new byte[FileUpload1.PostedFile.ContentLength];

                    Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(input.ToArray(), 0, input.ToArray().Length);
                }
                */
            }
        }

        void updateUserPersonalDetails()
        {
            try
            {
                string filepath = "~/Proof/";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(Server.MapPath("Proof/" + filename));
                    filepath = "~/Proof/" + filename;
                    lblmsg.Text = "File Uploaded.";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
                
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE people SET name=@name, email=@email, contactnum=@contactnum, dateofbirth=@dateofbirth, gender=@gender, usertype=@usertype, accountstatus=@accountstatus, proof=@proof WHERE email='" + Session["email"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contactnum", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@usertype", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@accountstatus", "Pending");
                cmd.Parameters.AddWithValue("@proof", filepath);

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

        protected void changepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword.aspx");
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