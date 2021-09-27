namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;

    public class WalletsController : Controller
    {
        private readonly IWalletsService walletsService;
        private readonly UserManager<ApplicationUser> userManager;

        public WalletsController(
            IWalletsService walletsService,
            UserManager<ApplicationUser> userManager)
        {;
            this.walletsService = walletsService;
            this.userManager = userManager;
        }

        public IActionResult MyWallet()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var wallet = await this.walletsService.CreateAsync(user.Id);
            this.TempData["SuccessfullyCreatedWalletMessage"] = "Congratulations your wallet is successfully created!";
            this.TempData["SuccessfullyBonusMessage"] = "BONUS: We boost your wallet with 10.99lv and 100 coins!";
            return this.RedirectToAction("MyWallet");
        }
    }
}
