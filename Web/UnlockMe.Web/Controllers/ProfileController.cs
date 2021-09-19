namespace UnlockMe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult My()
        {
            return this.View();
        }
    }
}
