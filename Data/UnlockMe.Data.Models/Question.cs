namespace UnlockMe.Data.Models
{
    using UnlockMe.Data.Common.Models;

    public class Question : BaseDeletableModel<int>
    {
        public string Email { get; set; }

        public string QuestionAsk { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
