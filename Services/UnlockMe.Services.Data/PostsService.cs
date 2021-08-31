namespace UnlockMe.Services.Data
{
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Web.ViewModels.Post;

    public class PostsService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task CreateAsync(CreatePostInputModel input)
        {
            var post = new Post
            {
                Title = input.Title,
                Description = input.Description,
                TagId = 2,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }
    }
}
