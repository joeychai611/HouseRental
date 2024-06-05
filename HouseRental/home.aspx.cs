using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace HouseRental
{
    public partial class home : System.Web.UI.Page
    {
        public List<string> HouseType = new List<string>();
        public List<string> CityList = new List<string>();
        public List<string> RentPriceList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True"))
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

        protected void customSearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}