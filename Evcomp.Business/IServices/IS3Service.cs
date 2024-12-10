using Microsoft.AspNetCore.Http;

namespace Evcomp.Business.IServices
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(string fileName, IFormFile file);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
