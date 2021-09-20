namespace UnlockMe.Web.ViewModels.Question
{
    using System.ComponentModel.DataAnnotations;

    public class CreateQuestionInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string QuestionAsk { get; set; }
    }
}
