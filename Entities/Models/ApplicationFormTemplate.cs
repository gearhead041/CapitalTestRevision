namespace Entities.Models;

/// <summary>
/// Represents the Application Form for a Program in the database.
/// </summary>
public class ApplicationFormTemplate
{
    public string CoverImage { get; set; } = string.Empty;
    public FileUpload? CoverImageUpload { get; set; } = null;
    public PersonalInformation PersonalInformation { get; set; } = new PersonalInformation();
    public Profile Profile { get; set; } = new Profile();
    public ICollection<Question>? AdditionalQuestions { get; set; }
}
