using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUpload;
        private readonly IWebHostEnvironment _evn;

        public FileUploadController(IFileUploadService fileUpload, IWebHostEnvironment evn)
        {
            _fileUpload = fileUpload;
            _evn = evn;
        }
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile()
        {
            var file = Request.Form.Files[0];
            if (file != null)
            {
                //string f = await accTransactionService.GetUploadFileName(file);
                return Ok(await _fileUpload.GetUploadFileName(file));
            }
            else { return BadRequest(); }
        }

        [HttpGet("DownloadFile/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_evn.ContentRootPath, "Uploads", fileName);
                var memory = new MemoryStream();

                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memory);
                }
                memory.Position = 0;
                string contentType = GetMimeTypeForFileExtension(Path.GetFileName(filePath));
                return File(memory, contentType, Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public static string GetMimeTypeForFileExtension(string filePath)
        {
            const string DefaultContentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
    }
}
