
namespace Entities.Dtos;
/// <summary>
/// PreviewDTO class for a Program
/// </summary>
public class PreviewDto
{
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] SKilsRequired { get; set; }  =  Array.Empty<string>();
    public string Benefits { get; set; } = string.Empty;
    public string ApplicationCriteria { get; set; } = string.Empty;
}
