using System.Net.Mail;

public class EmailSendManager
{
    public static void SendMail(string toMail, string subject, string emailBody)
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(toMail);
        mail.From = new MailAddress("joeychai0611@gmail.com");
        mail.Subject = subject;

        mail.Body = emailBody;
        mail.IsBodyHtml = true;

        SmtpClient smtp = new SmtpClient();
        smtp.Port = 587; // 25 465
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Host = "smtp.gmail.com";
        smtp.Credentials = new System.Net.NetworkCredential("joeychai0611@gmail.com", "pkte keth bwzc kcwj");
        smtp.Send(mail);
    }
}