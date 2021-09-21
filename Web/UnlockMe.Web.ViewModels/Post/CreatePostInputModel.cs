namespace UnlockMe.Web.ViewModels.Post
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreatePostInputModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        // public int TagId { get; set; } - TODO if user add Tag or Category
        public string AddedByUserId { get; set; }
    }
}
