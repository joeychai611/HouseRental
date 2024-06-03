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
            SqlConnection con = new SqlConnection("server=47.110.156.155;Initial Catalog=houserentalDB;User ID=sa;Password=Bk1770!Dev@;Persist Security Info=True;Connect Timeout=300;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
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