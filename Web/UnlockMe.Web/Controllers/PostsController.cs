using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnlockMe.Services.Data;
using UnlockMe.Web.ViewModels.Post;

namespace UnlockMe.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.postService.CreateAsync(input);
            // TODO - Redirect to the post view page later
            return this.Redirect("/");
        }
    }
}
