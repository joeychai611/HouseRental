using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Net.Http;
using System.Threading.Tasks;

namespace HouseRental
{
    public partial class payment : System.Web.UI.Page
    {
        private static string PayPalClientId => System.Configuration.ConfigurationManager.AppSettings["PayPalClientId"];
        private static string PayPalClientSecret => System.Configuration.ConfigurationManager.AppSettings["PayPalClientSecret"];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString != null && Request.QueryString.Count != 0)
            {
                string approvalToken = Request.QueryString["token"];
                var response = Task.Run(async () => await captureOrder(approvalToken));

                if(response.Result != null)
                {
                    Order result = response.Result.Result<Order>();
                    Label1.Text = result.Status;
                }
                else
                {

                }
            }
        }

        public async static Task<string> createOrder()
        {
            var order = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                new PurchaseUnitRequest()
                {
                    AmountWithBreakdown = new AmountWithBreakdown()
                    {
                        CurrencyCode = "USD",
                        Value = "100.00"
                    }
                }
                },
                ApplicationContext = new ApplicationContext()
                {
                    ReturnUrl = "https://localhost:44358/payment.aspx",
                    CancelUrl = "https://localhost:44358/payment.aspx"
                }
            };

            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(order);
            var environment = new SandboxEnvironment(PayPalClientId, PayPalClientSecret);
            var response = await (new PayPalHttpClient(environment).Execute(request));
            var statusCode = response.StatusCode;
            Order result = response.Result<Order>();
            Console.WriteLine("Status:{0}", result.Status);
            Console.WriteLine("Order Id:{0}", result.Id);
            Console.WriteLine("Intent:{0}", result.CheckoutPaymentIntent);
            Console.WriteLine("Links:");
            foreach (LinkDescription link in result.Links)
            {
                Console.WriteLine("\t{0}:{1}\tCall Type:{2}", link.Rel, link.Href, link.Method);
            }
            return GetApprovalUrl(result);
        }

        public async static Task<PayPalHttp.HttpResponse> captureOrder(string token)
        {
            var request = new OrdersCaptureRequest(token);
            request.RequestBody(new OrderActionRequest());
            var environment = new SandboxEnvironment(PayPalClientId, PayPalClientSecret);
            var response = await (new PayPalHttpClient(environment).Execute(request));
            var statusCode = response.StatusCode;
            Order result = response.Result<Order>();
            Console.WriteLine("Status:{0}", result.Status);
            Console.WriteLine("Capture Id:{0}", result.Id);
            return response;
        }

        public static string GetApprovalUrl(Order result)
        {
            if (result.Links != null)
            {
                LinkDescription approvalLink = result.Links.Find(link => link.Rel.ToLower() == "approve");
                if (approvalLink != null)
                {
                    return approvalLink.Href;
                }
            }
            return "https://www.example.com";
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            var response = Task.Run(async () => await createOrder());
            Response.Redirect(response.Result);
        }
    }
}