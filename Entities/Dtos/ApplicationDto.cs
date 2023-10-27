using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;
/// <summary>
/// Application Form Dto for a Program
/// </summary>
public class ApplicationDto
{

    public string? CoverImage { get; set; } = null;
    public IFormFile? CoverImageUpload { get; set; } = null;
    public PersonalInformation PersonalInformation { get; set; } = new PersonalInformation();
    public Profile Profile { get; set; } = new Profile();
    public ICollection<Question> AdditionalQuestions { get; set; } = new List<Question>();
}
