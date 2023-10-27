
namespace Entities.Models;

public class FileUpload
{
    public string ContentType { get; set; } = string.Empty;
    public long Length { get; set; }
    public string FileName { get; set; } = string.Empty;
}
