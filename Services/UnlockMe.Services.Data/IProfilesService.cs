namespace UnlockMe.Services.Data
{
    using System.Collections.Generic;

    public interface IProfilesService
    {
        IEnumerable<T> GetRandomPosts<T>(int count = 3);
    }
}
