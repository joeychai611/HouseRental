using System;
using Stripe;

namespace HouseRental
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_51NHU1CHEhs4SRxhEUf0sTeb4zLkZGsmNTYrnzO57hBbSrx8xRECvndJfZda4zI9pX9lNvOqUYAMAkmiljmtY2n5l008fvuy52x";
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}