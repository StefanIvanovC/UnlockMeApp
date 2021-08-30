namespace UnlockMe.Data.Models
{
    using UnlockMe.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        // Tag------------------
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        // Idenntity ----------------
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
