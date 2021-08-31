namespace UnlockMe.Data.Models
{
    using System.Collections.Generic;

    using UnlockMe.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
