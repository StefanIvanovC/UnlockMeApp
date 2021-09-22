namespace UnlockMe.Data.Models
{
    using UnlockMe.Data.Common.Models;

    public class Wallet : BaseDeletableModel<string>
    {
        public decimal Money { get; set; }

        public int Coins { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
