namespace UnlockMe.Data.Models
{
    using UnlockMe.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
