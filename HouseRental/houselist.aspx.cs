using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class houselist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGrid(Request["keyword"]);
                loadRecord(0);
            }
        }

        protected void BindGrid(string searchParam)
        {
            string titleSearch = searchParam == null || searchParam == "" ? customSearchTextBox.Text : searchParam;
            using (SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT *,(SELECT TOP 1 image FROM roompicture rp WHERE rp.roomID = room.ID ORDER BY rp.id) as image FROM room WHERE [hname] LIKE '%" + titleSearch + "%' OR [housetype] LIKE '%" + titleSearch + "%' OR [city] LIKE '%" + titleSearch + "%' OR [rentprice] LIKE '%" + titleSearch + "%' ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        rpQuestions.DataSource = dt;
                        rpQuestions.DataBind();
                    }
                }
            }
        }

        protected void customSearchButton_Click(object sender, EventArgs e)
        {
            string titleSearch = customSearchTextBox.Text;
            using (SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *,(SELECT TOP 1 image FROM roompicture rp WHERE rp.roomID = room.ID ORDER BY rp.id) as image FROM room", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT *,(SELECT TOP 1 image FROM roompicture rp WHERE rp.roomID = room.ID ORDER BY rp.id) as image FROM room WHERE [hname] LIKE '%" + titleSearch + "%' OR [housetype] LIKE '%" + titleSearch + "%' OR [city] LIKE '%" + titleSearch + "%' OR [rentprice] LIKE '%" + titleSearch + "%' ", con))
                    {
                        try
                        {
                            con.Open();
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            rpQuestions.DataSource = ds;
                            rpQuestions.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(@"<SCRIPT LANGUAGE=""JavaScript"">alert('" + "Message:" + ex.Message + "')</SCRIPT>");
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            string id = btn.CommandArgument;
            Response.Redirect("house.aspx?ID=" + ID);
        }

        private void loadRecord(int getPageNo)
        {
            SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
            SqlDataAdapter dap;
            DataTable dtp = new DataTable();
            PagedDataSource pds;

            dap = new SqlDataAdapter("SELECT *,(SELECT TOP 1 image FROM roompicture rp WHERE rp.roomID = room.ID ORDER BY rp.id) as image FROM room", con);
            dap.Fill(dtp);

            pds = new PagedDataSource();
            pds.DataSource = dtp.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 5;

            Session["CPNo"] = getPageNo;

            if (getPageNo > (pds.PageCount - 1))
                getPageNo = pds.PageCount - 1;
            if (getPageNo < 0)
                getPageNo = 0;

            pds.CurrentPageIndex = getPageNo;

            if (dtp.Rows.Count > 0)
            {
                rpQuestions.DataSource = pds;
                rpQuestions.DataBind();
            }
            else
            { }


            //enable & disabled previous and Next button
            if (pds.IsLastPage)
                LinkButton2.Enabled = false;
            else
                LinkButton2.Enabled = true;

            if (pds.IsFirstPage)
                LinkButton1.Enabled = false;
            else
                LinkButton1.Enabled = true;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["CPNo"] = (int.Parse(Session["CPNo"].ToString()) + 1).ToString();
            loadRecord(int.Parse(Session["CPNo"].ToString()));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["CPNo"] = (int.Parse(Session["CPNo"].ToString()) - 1).ToString();
            loadRecord(int.Parse(Session["CPNo"].ToString()));
        }
    }
}