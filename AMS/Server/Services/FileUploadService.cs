
namespace AMS.Server.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _evn;

        public FileUploadService(IWebHostEnvironment evn)
        {
            _evn = evn;
        }
        public async Task<string> GetUploadFileName(IFormFile obj)
        {
            string? uniqueFileName = null;

            if (obj != null)
            {
                try
                {
                    string uploadsFolder = Path.Combine(_evn.ContentRootPath, "Uploads");
                    uniqueFileName = Path.GetRandomFileName() + "_" + obj.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    await using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await obj.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }

            }
            return uniqueFileName;
        }
    }
}
