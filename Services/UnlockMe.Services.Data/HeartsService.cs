namespace UnlockMe.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;

    public class HeartsService : IHeartsService
    {
        private readonly IRepository<Heart> heartsRepository;

        public HeartsService(IRepository<Heart> heartsRepository)
        {
            this.heartsRepository = heartsRepository;
        }

        public int GetHeartsCount(int postId)
        {
            var currentCountHearts = this.heartsRepository
                .All()
                .FirstOrDefault(x => x.PostId == postId)
                .CountHearts;

            return currentCountHearts;
        }

        public async Task SetHeartAsync(int postId, string userId, int value)
        {
            var heart = this.heartsRepository
                 .All()
                 .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (heart == null)
            {
                heart = new Heart
                {
                    PostId = postId,
                    UserId = userId,
                    CountHearts = 0,
                };

                await this.heartsRepository.AddAsync(heart);
            }

            await this.heartsRepository.SaveChangesAsync();
        }
    }
}
