using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace HouseRental
{
    public partial class landlordReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetChartData();
            }
        }

        private void GetChartData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from payment", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            Chart1.Series["Series1"].XValueMember = "details";
            Chart1.Series["Series1"].YValueMembers = "total";
            Chart1.DataSource = rdr;
            Chart1.DataBind();
        }

    }
}