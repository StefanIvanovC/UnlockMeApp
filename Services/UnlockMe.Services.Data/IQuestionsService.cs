namespace UnlockMe.Services.Data
{
    using System.Threading.Tasks;

    using UnlockMe.Web.ViewModels.Question;

    public interface IQuestionsService
    {
        Task CreateAsync(CreateQuestionInputModel input, string userId);
    }
}
