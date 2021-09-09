using Microsoft.AspNetCore.Mvc;

namespace UnlockMe.Web.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Question()
        {
            return this.View();
        }
    }
}
