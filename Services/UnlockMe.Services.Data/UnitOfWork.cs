namespace UnlockMe.Services.Data
{
    using System;

    using Microsoft.AspNetCore.Http;

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
        }

        public void UploadPicture(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
