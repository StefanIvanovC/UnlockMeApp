namespace UnlockMe.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Web.ViewModels.Post;

    public class WalletsService : IWalletsService
    {
        private readonly IDeletableEntityRepository<Wallet> walletsRepository;

        public WalletsService(IDeletableEntityRepository<Wallet> walletsRepository)
        {
            this.walletsRepository = walletsRepository;
        }

        public async Task Create()
        {
            var wallet = new Wallet { Coins = 100, Money = 10.99m };
            await this.walletsRepository.AddAsync(wallet);
            await this.walletsRepository.SaveChangesAsync();
        }
    }
}
