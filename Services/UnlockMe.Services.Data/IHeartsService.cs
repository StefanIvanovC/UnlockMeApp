namespace UnlockMe.Services.Data
{
    using System.Threading.Tasks;

    public interface IHeartsService
    {
        Task SetHeartAsync(int postId, string userId, int value);

        int GetHeartsCount(int postId);
    }
}
