using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HouseRental
{
    /// <summary>
    /// Summary description for Webhooks
    /// </summary>
    public class Webhooks : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var endpointSecret = "whsec_b4a78f30c20b0187259cf928da70b8de5c5c6fcfdc6135746bc66cf40fe88063";
            var json = new StreamReader(context.Request.InputStream).ReadToEnd();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    context.Request.Headers["Stripe-Signature"],
                    endpointSecret
                );

                switch (stripeEvent.Type)
                {
                    case Events.PaymentIntentSucceeded:
                        // look up the payment in the database and update it's state
                        // fulfill order
                        // send a customer email
                        // 
                        var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                        Console.WriteLine($"Payment Succeeded {paymentIntent.Id} for ${paymentIntent.Amount}");
                        break;
                    default:
                        Console.WriteLine($"Got event {stripeEvent.Type}");
                        break;
                }
            }
            catch (StripeException e)
            {
                Console.WriteLine(e);
                throw e;
            }
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