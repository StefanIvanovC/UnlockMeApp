namespace UnlockMe.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UnlockMe.Web.ViewModels.Post;

    public interface IPostService
    {
        Task CreateAsync(CreatePostInputModel input, string userId, string picturePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        int GetCount();

        T GetById<T>(int id);

        IEnumerable<T> GetRandomPosts<T>(int count = 3);
    }
}
