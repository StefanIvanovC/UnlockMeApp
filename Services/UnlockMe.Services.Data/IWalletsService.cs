namespace UnlockMe.Services.Data
{
    using System.Threading.Tasks;
    using UnlockMe.Data.Models;

    public interface IWalletsService
    {
        Task<Wallet> CreateAsync(string userId);
    }
}
