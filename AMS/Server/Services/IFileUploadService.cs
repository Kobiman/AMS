namespace AMS.Server.Services
{
    public interface IFileUploadService
    {
        public Task<string> GetUploadFileName(IFormFile obj);
    }
}
