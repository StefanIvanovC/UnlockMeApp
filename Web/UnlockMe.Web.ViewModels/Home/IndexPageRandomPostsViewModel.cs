namespace UnlockMe.Web.ViewModels.Home
{
    using AutoMapper;
    using System.Linq;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class IndexPageRandomPostsViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, IndexPageRandomPostsViewModel>()
                .ForMember(x => x.ImagePath, opt =>
                opt.MapFrom(x =>
            "/pictures/posts/" + x.Pictures.FirstOrDefault().Id + "." + x.Pictures.FirstOrDefault().Extension));
        }
    }
}
