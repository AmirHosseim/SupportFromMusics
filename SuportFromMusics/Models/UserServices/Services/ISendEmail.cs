using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UserServices.Services
{
    public interface ISendEmail
    {
        void sendEmail(string To, string Message,string subject = "رمز عبور");
    }

    public class SendPasswordWithEmail : ISendEmail
    {
        public void sendEmail(string To, string Message,string subject = "رمز عبور")
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("Jafariamirhossein15@gmail.com");
            mail.To.Add(new MailAddress(To));
            mail.Subject = subject;
            mail.Body = Message;
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("JafariAmirhossein15@gmail.com", "cmfklcewzlaredrr");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(mail);
        }
    }

}
