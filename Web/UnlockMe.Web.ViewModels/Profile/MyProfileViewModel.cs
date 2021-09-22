namespace UnlockMe.Web.ViewModels.Profile
{
    using System;

    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class MyProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string ProfileImagePath { get; set; }

        public string AboutMe { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
