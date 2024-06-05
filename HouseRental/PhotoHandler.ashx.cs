using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HouseRental
{
    /// <summary>
    /// Summary description for PhotoHandler
    /// </summary>
    public class PhotoHandler : IHttpHandler
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["houserentalDBConnectionString"].ConnectionString);

        public void ProcessRequest(HttpContext context)
        {
            string ID = context.Request.QueryString["ID"].ToString();
            string qr = "select proof from proof where ID=" + ID;
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            context.Response.ContentType = "Proof/";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + context.Request.QueryString[0].ToString());
            byte[] myphoto = (byte[])ds.Tables[0].Rows[0]["proof"];
            context.Response.BinaryWrite(myphoto);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}