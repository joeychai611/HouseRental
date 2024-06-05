using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class houselist : System.Web.UI.Page
    {
        public List<string> HouseType = new List<string>();
        public List<string> CityList = new List<string>();
        public List<string> RentPriceList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                loadRecord(Request["housetype"], Request["rentprice"], Request["city"], Request["keyword"], 0);

                using (SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;"))
                {
                    SqlCommand cmd = new SqlCommand("select top 10 housetype from room group by housetype", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HouseType.Add((string)dt.Rows[i]["housetype"]);
                    }

                    cmd = new SqlCommand("select top 10 city from room group by city", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CityList.Add((string)dt.Rows[i]["city"]);
                    }

                    cmd = new SqlCommand("select top 10 rentprice from room group by rentprice", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RentPriceList.Add(dt.Rows[i]["rentprice"].ToString());
                    }
                    cmd.Dispose();
                    da.Dispose();
                    dt.Dispose();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            string id = btn.CommandArgument;
            Response.Redirect("house.aspx?ID=" + ID);
        }

        private void loadRecord(string housetype, string rentprice, string city, string keyword, int getPageNo)
        {
            using (SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;"))
            {

                string sql = "SELECT *,(SELECT TOP 1 image FROM roompicture rp WHERE rp.roomID = room.ID ORDER BY rp.id) as image FROM room WHERE 1=1 ";
                if (housetype != null && housetype != "")
                    sql += $" and housetype like '%{housetype}%' ";
                if (rentprice != null && rentprice != "")
                    sql += $" and rentprice={rentprice} ";
                if (city != null && city != "")
                    sql += $"and city like '%{city}%'";
                if (keyword != null && keyword != "")
                    sql += $" or( [hname] LIKE '%{keyword}%' OR [housetype] LIKE '%{keyword}%' OR [city] LIKE '%{keyword}%' OR [rentprice] LIKE '%{keyword}%')";

                using (var dap = new SqlDataAdapter(sql, con))
                {
                    using (DataTable dtp = new DataTable())
                    {
                        dap.Fill(dtp);

                        var pds = new PagedDataSource
                        {
                            DataSource = dtp.DefaultView,
                            AllowPaging = true,
                            PageSize = 5
                        };

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

                        LinkButton2.Enabled = pds.IsLastPage;
                        LinkButton1.Enabled = pds.IsFirstPage;
                    }
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["CPNo"] = (int.Parse(Session["CPNo"].ToString()) + 1).ToString();
            loadRecord(Request["housetype"], Request["rentprice"], Request["city"], Request["keyword"], int.Parse(Session["CPNo"].ToString()));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["CPNo"] = (int.Parse(Session["CPNo"].ToString()) - 1).ToString();
            loadRecord(Request["housetype"], Request["rentprice"], Request["city"], Request["keyword"], int.Parse(Session["CPNo"].ToString()));
        }
    }
}