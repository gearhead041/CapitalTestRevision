namespace Entities.Models;

/// <summary>
/// Represents the Personal Information Section in Application Form for a program in the database.
/// First Name, last name and Email are default values.
/// </summary>
public class PersonalInformation
{
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
