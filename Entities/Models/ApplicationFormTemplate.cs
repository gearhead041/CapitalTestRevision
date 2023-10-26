namespace Entities.Models;

/// <summary>
/// Represents the Application Form for a Program in the database.
/// </summary>
public class ApplicationFormTemplate
{
    public string CoverImage { get; set; } = string.Empty;
    public PersonalInformation PersonalInformation { get; set; } = new PersonalInformation();
    public Profile Profile { get; set; } = new Profile();
    public IEnumerable<Question> AdditionalQuestions { get; set; } = Enumerable.Empty<Question>();
}
