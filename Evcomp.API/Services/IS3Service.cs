namespace Evcomp.API.Services
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(string fileName, IFormFile file);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
