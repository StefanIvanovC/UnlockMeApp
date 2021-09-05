namespace UnlockMe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        public IActionResult My()
        {
            return this.View();
        }
    }
}
