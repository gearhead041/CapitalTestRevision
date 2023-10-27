using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Contracts.Services;
using Microsoft.AspNetCore.Http;

namespace Services;

public class CloudinaryFileUploadService : IFileUploadService
{
    const string Cloud = "dsan82coz";
    const string ApiKey = "742749662459879";
    const string ApiSecret = "npGiO_lv57fL3SFa055LvBBBI9k";
    private readonly Cloudinary _cloudinary;

    public CloudinaryFileUploadService()
    {
        Account account = new(
          Cloud,
          ApiKey,
          ApiSecret);

        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true;
    }

    public async Task<string> DeleteFileAsync(string fileUrl)
    {
        var Id = new Uri(fileUrl).Segments.Last().Split('.').First();
        await Console.Out.WriteLineAsync(fileUrl);
        await Console.Out.WriteLineAsync(Id);
        var deletionParams = new DeletionParams(Id);
        var result = await _cloudinary.DestroyAsync(deletionParams);
        if (result.Error != null)
        {
            throw new Exception($"Cloudinary error occured: {result.Error.Message}");
        }

        return result.Result;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        // Will also work for pdfs, 
        //https://cloudinary.com/blog/uploading_managing_and_delivering_pdfs
        var uploadparams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, memoryStream),
            AssetFolder = "CapitalTest",
            UseFilename = true,

        };

        var result = _cloudinary.Upload(uploadparams);
        if (result.Error != null)
        {
            throw new Exception($"Cloudinary error occured: {result.Error.Message}");
        }

        return result.SecureUrl.ToString();
    }
}