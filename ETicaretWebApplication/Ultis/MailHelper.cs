using ETicaret_Core.Entities;
using System.Net;
using System.Net.Mail;

namespace ETicaretWebApplication.Ultis
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadi.com",587);
            smtpClient.Credentials = new NetworkCredential("info@siteadi.com","mailşifresi");
            smtpClient.EnableSsl = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadi.com");
            message.To.Add("bilgi@siteadi.com");
            message.Subject = "Siteden Mesaj Geldi";
            message.Body = $"İsim:{contact.Name} - Soyisim:{contact.Surname} - Email:{contact.Email} -Telefon:{contact.Phone}-Mesaj:{contact.Message}" ;
            message.IsBodyHtml = true;
            await smtpClient.SendMailAsync(message);   
            smtpClient.Dispose();
        }
    }
}
