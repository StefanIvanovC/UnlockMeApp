namespace UnlockMe.Web.ViewModels.Profile
{
    using System;
    using System.Collections.Generic;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;
    using UnlockMe.Web.ViewModels.Post;

    public class MyProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string ProfileImagePath { get; set; }

        public string UserName { get; set; }

        public string AboutMe { get; set; }

        public DateTime CreatedOn { get; set; }

        public int PostsCount { get; set; }

        public string Email { get; set; }

        public IEnumerable<SinglePostViewModel> Posts { get; set; }
    }
}
