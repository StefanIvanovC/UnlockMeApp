namespace UnlockMe.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Web.ViewModels.Question;

    public class QuestionsService : IQuestionsService
    {
        private readonly IDeletableEntityRepository<Question> questionRepository;

        public QuestionsService(
            IDeletableEntityRepository<Question> questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public async Task CreateAsync(CreateQuestionInputModel input, string userId)
        {
            var question = new Question
            {
                AddedByUserId = userId,
                Email = input.Email,
                QuestionAsk = input.QuestionAsk,
            };

            await this.questionRepository.AddAsync(question);
            await this.questionRepository.SaveChangesAsync();
        }
    }
}
