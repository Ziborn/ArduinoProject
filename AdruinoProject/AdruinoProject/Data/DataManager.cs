using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;

namespace AdruinoProject.Data
{
    public class DataManager
    {
        public void SendEMail()
        {
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Security alarm", "love.wick93@gmail.com"));
            message.To.Add(new MailboxAddress("Robin", "robin.mik23@gmail.com"));
            message.Subject = "Security breach";

            message.Body = new TextPart("html")
            {
                
                Text = @"<b>Hi Robin,</b><br>

<p>Someone just <span style='color:red'>triggered</span> your alarm. " + date + " " + time + "</p>"
            };



            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("love.wick93@gmail.com", "lgaoyrxmdragdqfr");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
