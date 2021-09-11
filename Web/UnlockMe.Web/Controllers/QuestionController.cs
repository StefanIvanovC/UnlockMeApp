namespace UnlockMe.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Services.Messaging;

    public class QuestionController : Controller
    {
        private readonly IEmailSender emailSender;

        public QuestionController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Question()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SendToEmail()
        {
            var html = new StringBuilder();
            html.AppendLine($"<h1>Hello From UnlockME</h1>");
            html.AppendLine($"<h2>I have some problem</h2>");
            html.AppendLine($"<h3>HELP ME</h3>");

            await this.emailSender.SendEmailAsync("UnlockMe@gmail.com", "UnlockMe", "piseves428@sicmag.com", "Some subject", html.ToString());
            return this.RedirectToAction("Index", "Home");
        }
    }
}
