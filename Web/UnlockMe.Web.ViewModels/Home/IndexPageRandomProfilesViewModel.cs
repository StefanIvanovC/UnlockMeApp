namespace UnlockMe.Web.ViewModels.Home
{
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class IndexPageRandomProfilesViewModel : IMapFrom<ApplicationUser> // , IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string AboutMe { get; set; }

        // public string ImagePath { get; set; }

    }
}
