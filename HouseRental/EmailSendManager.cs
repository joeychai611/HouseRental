using System.Net.Mail;
using System.Net;

public class EmailSendManager
{
    public static void SendMail(string toMail, string toName, string subject, string body)
    {
        var fromAddress = new MailAddress("Joeychai611@gmail.com", "Joeychai611");
        var toAddress = new MailAddress(toMail, toName);
        const string fromPassword = "admin123.";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            try
            {
                smtp.Send(message);
            }
            catch (System.Exception) { }
        }
    }
}