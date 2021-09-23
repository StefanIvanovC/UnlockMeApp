namespace UnlockMe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using UnlockMe.Data;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.Post;
    using UnlockMe.Web.ViewModels.Profile;

    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var posts = this.db.Posts.Where(p => p.AddedByUserId == user.Id);

            var viewModel = new MyProfileViewModel
            {
                UserName = user.UserName,
                AboutMe = user.AboutMe,
                CreatedOn = user.CreatedOn,
                PostsCount = posts.Count(),
            };

            return this.View(viewModel);
        }
    }
}
