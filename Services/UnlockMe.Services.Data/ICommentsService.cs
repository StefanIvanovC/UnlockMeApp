﻿namespace UnlockMe.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int postId, string userId, string content, int? parentId = null);
    }
}
