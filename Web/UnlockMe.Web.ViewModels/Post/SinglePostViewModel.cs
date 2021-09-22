namespace UnlockMe.Web.ViewModels.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class SinglePostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserUserName { get; set; }

        public string PictureUrl { get; set; }

        public string TagName { get; set; }

        public int HeartCount { get; set; }

        public IEnumerable<PostCommentViewModel> Comments { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, SinglePostViewModel>()

                // .ForMember(x => x.HeartCount, opt => opt.MapFrom(x => x.Hearts))
                .ForMember(x => x.PictureUrl, opt =>
                      opt.MapFrom(x =>
                 "/pictures/posts/" + x.Pictures.FirstOrDefault().Id + "." + x.Pictures.FirstOrDefault().Extension));
        }
    }
}
