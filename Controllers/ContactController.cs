using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using pr2.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly EmailSettings _emailSettings;

    public ContactController(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactForm model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.AppPassword),
                    EnableSsl = true,
                };

                var messageToYou = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail),
                    Subject = "📬 New Contact Form Submission",
                    Body = $"You have a new message from your portfolio website:\n\n" +
                           $"Name: {model.Name}\n" +
                           $"Email: {model.Email}\n" +
                           $"Message:\n{model.Message}",
                    IsBodyHtml = false,
                };
                messageToYou.To.Add(_emailSettings.ReceiverEmail);

                await smtpClient.SendMailAsync(messageToYou);

                var confirmation = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail),
                    Subject = "✅ Thank you for contacting Santosh Dhabdage",
                    Body = $"Hi {model.Name},\n\nThank you for reaching out! I have received your message and will get back to you soon.\n\nBest regards,\nSantosh Dhabdage",
                    IsBodyHtml = false,
                };
                confirmation.To.Add(model.Email);

                await smtpClient.SendMailAsync(confirmation);

                ViewBag.Message = "✅ Thank you for contacting me! I have received your message and sent you a confirmation email.";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"❌ Error sending your message. Please try again later. Details: {ex.Message}";
            }
        }

        return View();
    }
}
