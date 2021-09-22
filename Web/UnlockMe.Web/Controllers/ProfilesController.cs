namespace UnlockMe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;

    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            IProfileService profileService,
            UserManager<ApplicationUser> userManager)
        {
            this.profileService = profileService;
            this.userManager = userManager;
        }

        public IActionResult MyProfile()
        {
            return this.Ok();
        }
    }
}
