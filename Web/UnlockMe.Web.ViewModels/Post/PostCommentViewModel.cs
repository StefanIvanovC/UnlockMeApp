namespace UnlockMe.Web.ViewModels.Post
{
    using System;

    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}
