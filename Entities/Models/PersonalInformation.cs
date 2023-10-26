namespace Entities.Models;

/// <summary>
/// Represents the Personal Information Section in Application Form for a program in the database.
/// </summary>
public class PersonalInformation
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; }   = string.Empty;
    public bool PhoneInternal {  get; set; }
    public bool PhoneHidden { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public bool NationalityInternal { get; set; }
    public bool NationalityHidden { get; set; }
    public string CurrentResidence { get; set; } = string.Empty;
    public bool CurrentResidenceInternal { get; set; }
    public bool CurrentResidenceHidden { get; set; }
    public string IDNumber { get; set; } = string.Empty;
    public bool IDNumberInternal { get; set; }
    public bool IDNumberHidden { get; set; }
    public DateTime DateOfBirth { get; set; } //TODO also here, might have to change to string
    public bool DateOfBirthInternal { get;set; }
    public bool DateOfBirthHidden { get; set; }
    public string Gender { get; set; } = string.Empty;
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}