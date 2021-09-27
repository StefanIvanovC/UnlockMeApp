namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.Wallet;

    public class WalletsController : Controller
    {
        private readonly IDeletableEntityRepository<Wallet> walletRepository;
        private readonly IWalletsService walletsService;
        private readonly UserManager<ApplicationUser> userManager;

        public WalletsController(
            IDeletableEntityRepository<Wallet> walletRepository,
            IWalletsService walletsService,
            UserManager<ApplicationUser> userManager)
        {
            this.walletRepository = walletRepository;
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
            var wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user.Id, Coins = 100, Money = 10.99m };
            await this.walletRepository.AddAsync(wallet);
            await this.walletRepository.SaveChangesAsync();
            return this.RedirectToAction("MyWallet");
        }
    }
}
