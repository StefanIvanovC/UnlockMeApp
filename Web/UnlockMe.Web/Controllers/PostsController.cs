﻿namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.Post;

    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public PostsController(
            IPostService postService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.postService = postService;
            this.userManager = userManager;
            this.environment = environment;
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
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.postService.CreateAsync(input, user.Id, $"{this.environment.ContentRootPath}/pictures");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

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
