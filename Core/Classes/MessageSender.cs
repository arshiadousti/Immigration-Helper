using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Core.Classes
{
    public class MessageSender
    {
        public void SendEmail(string to , string subject , string body )
        {
            MailMessage mail = new MailMessage();
            SmtpClient Client = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("arshiadousti79@gmail.com", "دفتر مهاجرتی");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            mail.IsBodyHtml = true;

            Client.Port = 587;
            Client.Credentials = new NetworkCredential("arshiadousti79@gmail.com", "34407514");
            Client.EnableSsl = true;

            Client.Send(mail);
        }
    }
}
