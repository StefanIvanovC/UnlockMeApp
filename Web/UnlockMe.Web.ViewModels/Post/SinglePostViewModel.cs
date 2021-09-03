﻿namespace UnlockMe.Web.ViewModels.Post
{
    using System;
    using System.Linq;

    using AutoMapper;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class SinglePostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserUserName { get; set; }

        public string PictureUrl { get; set; }

        public string TagName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, SinglePostViewModel>()
                .ForMember(x => x.PictureUrl, opt =>
                opt.MapFrom(x =>
                 "/pictures/posts/" + x.Pictures.FirstOrDefault().Id + "." + x.Pictures.FirstOrDefault().Extension));
        }
    }
}