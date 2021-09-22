namespace UnlockMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using UnlockMe.Data.Common.Models;

    public class Heart : BaseModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CountHearts { get; set; }
    }
}
