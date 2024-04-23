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
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GAS8R8RV\\SQLEXPRESS;Initial Catalog=houserentalDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.PreRender += new EventHandler(GridView1_PreRender);
            bind();
        }

        public void bind()
        {
            con.Open();
            string query = "select * from proof";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            con.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        // using this pre render for hide the header text line if we dont have any data.
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count >0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            byte[] myphoto = FileUpload1.FileBytes;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string insertUpload = "INSERT INTO proof (proof) VALUES (@proof)";
            SqlCommand insertCmd = new SqlCommand(insertUpload, con);
            insertCmd.Parameters.AddWithValue("@proof", myphoto);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}