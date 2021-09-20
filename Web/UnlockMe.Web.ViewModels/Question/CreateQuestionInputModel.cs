namespace UnlockMe.Web.ViewModels.Question
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateQuestionInputModel 
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Question { get; set; }
    }
}
