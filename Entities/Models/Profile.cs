namespace Entities.Models;

/// <summary>
/// Represents the profile section in the application form template for a program.
/// </summary>
public class Profile
{
    public Education Education { get; set; } = new Education();
    public bool EducationMandatory { get; set; }
    public bool EducationHidden { get; set; }
    public Experience Experience { get; set; } = new Experience();
    public bool ExperienceMandatory { get; set;}
    public bool ExperienceHidden { get; set;}
    public string Resume { get; set; } = string.Empty;//TODO handle file uploads into database
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}