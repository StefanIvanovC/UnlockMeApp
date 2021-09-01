namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.Post;

    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            IPostService postService,
            UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.postService.CreateAsync(input, user.Id);

            // TODO - Redirect to the post view page later
            return this.Redirect("/");
        }

        // Posts/All/3 "Page of"
        public IActionResult All(int id)
        {
            const int postsPerPage = 12;
            var viewModel = new PostListViewModel
            {
                PostsPerPage = postsPerPage,
                PageNumber = id,
                PostsCount = this.postService.GetCount(),
                Posts = this.postService.GetAll<PostInListViewModel>(id = 1, postsPerPage),
            };
            return this.View(viewModel);
        }
    }
}
