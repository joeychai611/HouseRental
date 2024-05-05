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
    public partial class houselist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGrid();
                loadRecord(0);
            }
        }

        protected void BindGrid()
        {
            string titleSearch = customSearchTextBox.Text;
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM room", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
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
        }

        protected void customSearchButton_Click(object sender, EventArgs e)
        {
            string titleSearch = customSearchTextBox.Text;
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM room", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM room WHERE [hname] LIKE '%" + titleSearch + "%' OR [housetype] LIKE '%" + titleSearch + "%' OR [city] LIKE '%" + titleSearch + "%' OR [rentprice] LIKE '%" + titleSearch + "%' ", con))
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
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
            SqlDataAdapter dap;
            DataTable dtp = new DataTable();
            PagedDataSource pds;

            dap = new SqlDataAdapter("SELECT * from room", con);
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