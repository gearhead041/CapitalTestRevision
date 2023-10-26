using Entities.Models;

namespace Entities.Dtos;
/// <summary>
/// Application Form Dto for a Program
/// </summary>
public class ApplicationDto
{
    public string? CoverImage { get; set; }
    public PersonalInformation? PersonalInformation { get; set; }
    public Profile? Profile { get; set; }
    public IEnumerable<Question>? AdditionalQuestions { get; set; }
}