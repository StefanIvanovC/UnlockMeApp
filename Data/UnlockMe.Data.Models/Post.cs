namespace UnlockMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using UnlockMe.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Pictures = new HashSet<Picture>();
            this.Votes = new HashSet<Vote>();
            this.Hearts = new HashSet<Heart>();
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        // Tag------------------
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        // Idenntity ----------------
        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        // Vote -----------------------
        public virtual ICollection<Vote> Votes { get; set; }

        // Heart ------------------
        public virtual ICollection<Heart> Hearts { get; set; }

        // Comments ---------------
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
