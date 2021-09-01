namespace UnlockMe.Web.ViewModels.Post
{
    using System.Linq;

    using AutoMapper;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class PostInListViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Desccription { get; set; }

        public string ImagePath { get; set; }

        public string TagName { get; set; }

        public int TagId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostInListViewModel>()
                .ForMember(x => x.ImagePath, opt =>
                opt.MapFrom(x =>
                 "/pictures/posts/" + x.Pictures.FirstOrDefault().Id + "." + x.Pictures.FirstOrDefault().Extension));
        }
    }
}
