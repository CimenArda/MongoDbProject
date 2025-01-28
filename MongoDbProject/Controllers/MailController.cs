using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MongoDbProject.Models;

namespace MongoDbProject.Controllers
{
    public class MailController : Controller
    {
        [HttpPost]
        public IActionResult SendMail(SendMailViewModel sendMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("İNDİRİM", "arda.1235850@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress(sendMailViewModel.Name, sendMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = $@"
                <div style=""font-family: 'Segoe UI', sans-serif; line-height: 1.8; color: #333;"">
    <h1 style=""color: #FF5722; font-size: 28px; text-transform: uppercase; margin-bottom: 10px;"">
        Tebrikler, <span style=""color: #FF9800;"">{sendMailViewModel.Name}!</span>
    </h1>
    <p style=""font-size: 16px;"">🎉 Sizin için özel bir <strong style=""color: #4CAF50;"">%25 indirim kodu</strong> kazandınız!</p>
    <p style=""font-size: 15px; margin-top: 10px;"">
        İlk siparişinizde bu kodu kullanarak harika avantajlardan faydalanabilirsiniz:
    </p>
    <div style=""padding: 15px; background: #FFF3E0; border-radius: 8px; border: 1px solid #FFCCBC; display: inline-block; margin: 15px 0;"">
        <strong style=""font-size: 22px; color: #FF5722;"">INDIRIM25</strong>
    </div>
    <p style=""font-size: 15px; margin-top: 20px;"">
        Keyifli alışverişler dileriz, <br>
        <strong style=""color: #FF9800;"">FoodMart</strong> 🍽️
    </p>
</div>";
            
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Tebrikler! %25 İndirim Kodunuzu Kazandınız";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("arda.1235850@gmail.com", "czigvitupnfmjshb");
            client.Send(mimeMessage);
            client.Disconnect(true);
            TempData["Message"] = "Mail başarıyla gönderildi!";
            return RedirectToAction("Index", "Default");
        }
    }
}
