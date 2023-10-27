
using Microsoft.AspNetCore.Http;

namespace Contracts.Services;

public interface IFileUploadService
{
    Task<string> UploadFileAsync(IFormFile file);
    Task<string> DeleteFileAsync(string fileId);
}
