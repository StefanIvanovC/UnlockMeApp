namespace UnlockMe.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels;
    using UnlockMe.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IPostService postService;

        public HomeController(
            ApplicationDbContext db,
            IPostService postService)
        {
            this.db = db;
            this.postService = postService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                PostCount = this.db.Posts.Count(),
                PicturesCount = this.db.Posts.Count(),
                UsersCount = this.db.Users.Count(),
                RandomPosts = this.postService.GetRandomPosts<IndexPageRandomPostsViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
