using System.Net;
using System.Net.Mail;

namespace HouseRental
{
    internal class EmailRegister
    {
        SmtpClient smtpClient;
        static string fromMail = "joeychai611";
        static string password = "joeychai611";

        public EmailRegister()
        {
            smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail, password)
            };
        }

        public void Send(string body, string toAddr)
        {
            using (var m = new MailMessage(fromMail, toAddr)
            {
                Subject = "Register",
                Body = body,
            })
            {
                m.IsBodyHtml = true;
                smtpClient.Send(m);
            }
        }
    }
}