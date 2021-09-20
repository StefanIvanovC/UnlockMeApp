namespace UnlockMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;
    using UnlockMe.Web.ViewModels.Post;

    public class PostsService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public PostsService(
            IDeletableEntityRepository<Post> postsRepository,
            IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.postsRepository = postsRepository;
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(CreatePostInputModel input, string userId, string picturePath)
        {
            var post = new Post
            {
                AddedByUserId = userId,
                Title = input.Title,
                Description = input.Description,
                TagId = 2,
            };

            var allowedExtensions = new[] { "jpg", "png" };

            var currentPicture = input.Picture;
            var currentPictureName = currentPicture.FileName;
            var extension = Path.GetExtension(currentPictureName).TrimStart('.');
            if (!allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid picture extension - {extension}");
            }

            var dbPicture = new Picture
            {
                AddedByUserId = userId,
                Post = post,
                Extension = extension,
            };

            post.Pictures.Add(dbPicture);
            Directory.CreateDirectory($"{picturePath}/pictures/");
            var physicalPath = $"{picturePath}/posts/{dbPicture.Id}.{extension}";

            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await currentPicture.CopyToAsync(fileStream);

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = this.postsRepository.All().FirstOrDefault(x => x.Id == id);
            this.postsRepository.Delete(post);
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

        public T GetById<T>(int id)
        {
           var singlePost = this.postsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

           return singlePost;
        }

        public int GetCommentsCount(int id)
        {
            var commentsCount = this.commentsRepository.All()
                .Where(c => c.Id == id)
                .Count();

            return commentsCount;
        }

        public int GetCount()
        {
            return this.postsRepository.All().Count();
        }

        public IEnumerable<T> GetRandomPosts<T>(int count = 3)
        {
            return this.postsRepository.All().OrderBy(x => Guid.NewGuid())
                .To<T>()
                .Take(count)
                .ToList();
        }
    }
}
