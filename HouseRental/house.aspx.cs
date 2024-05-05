using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HouseRental
{
    public partial class house1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblName.Text = HttpUtility.UrlDecode(Request.QueryString["hname"]);
                lblHousetype.Text = HttpUtility.UrlDecode(Request.QueryString["housetype"]);
                lblHousetype.Attributes.Add("class", "badge badge-pill badge-info");
                lblAddress.Text = HttpUtility.UrlDecode(Request.QueryString["address"]);
                lblPostcode.Text = HttpUtility.UrlDecode(Request.QueryString["postcode"]);
                lblCity.Text = HttpUtility.UrlDecode(Request.QueryString["city"]);
                lblDescription.Text = HttpUtility.UrlDecode(Request.QueryString["description"]);
                lblAccommodation.Text = HttpUtility.UrlDecode(Request.QueryString["accommodation"]);
                lblRentprice.Text = HttpUtility.UrlDecode(Request.QueryString["rentprice"]);
                lblRentprice.Attributes["style"] = "color:black; font-weight:bold;";
                lblDuration.Text = HttpUtility.UrlDecode(Request.QueryString["duration"]);
                lblStatus.Text = HttpUtility.UrlDecode(Request.QueryString["status"]);
                if (lblStatus.Text == "Available")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-success");

                }
                else if (lblStatus.Text == "Unavailable")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
            }

        }
    }
}