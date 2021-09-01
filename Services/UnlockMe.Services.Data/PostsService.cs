namespace UnlockMe.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;
    using UnlockMe.Web.ViewModels.Post;

    public class PostsService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task CreateAsync(CreatePostInputModel input, string userId)
        {
            var post = new Post
            {
                AddedByUserId = userId,
                Title = input.Title,
                Description = input.Description,
                TagId = 2,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var posts = this.postsRepository.AllAsNoTracking()
                 .OrderBy(x => x.Id)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .To<T>()
                 .ToList();

            return posts;
        }

        public int GetCount()
        {
            return this.postsRepository.All().Count();
        }
    }
}
