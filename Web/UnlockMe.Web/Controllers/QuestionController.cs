namespace UnlockMe.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;
    using UnlockMe.Services.Messaging;
    using UnlockMe.Web.ViewModels.Question;

    public class QuestionController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly IQuestionsService questionService;
        private readonly UserManager<ApplicationUser> userManager;

        public QuestionController(
            IEmailSender emailSender,
            IQuestionsService questionService,
            UserManager<ApplicationUser> userManager)
        {
            this.emailSender = emailSender;
            this.questionService = questionService;
            this.userManager = userManager;
        }

        public IActionResult Question()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Question(CreateQuestionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.questionService.CreateAsync(input, user.Id);

            // TODO - Redirect to the post view page later
            this.TempData["SuccsessfulQuestionCreateMessage"] = "Your custom question is sent succsessfully! Don't forget to check your email!";
            return this.Redirect("/Question/Question");
        }
    }
}
