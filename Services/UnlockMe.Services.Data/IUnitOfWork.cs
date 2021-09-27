namespace UnlockMe.Services.Data
{
    using Microsoft.AspNetCore.Http;

    public interface IUnitOfWork
    {
        void UploadPicture(IFormFile file);
    }
}
