namespace UnlockMe.Web.ViewModels.Wallet
{
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class CreateWalletInputModel : IMapFrom<Wallet>
    {
        public string UserId { get; set; }
    }
}
