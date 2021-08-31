namespace UnlockMe.Services.Data
{
    using System.Threading.Tasks;

    using UnlockMe.Web.ViewModels.Post;

    public interface IPostService
    {
        Task CreateAsync(CreatePostInputModel input);
    }
}
