namespace UnlockMe.Data.Models
{
    using System;

    using UnlockMe.Data.Common.Models;

    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string Extension { get; set; }
    }
}
