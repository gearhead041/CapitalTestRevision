namespace Entities.Models;

/// <summary>
/// Represents the Personal Information Section in Application Form for a program in the database.
/// </summary>
public class PersonalInformation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool PhoneInternal {  get; set; }
    public bool PhoneHidden { get; set; }
    public string Nationality { get; set; }
    public bool NationalityInternal { get; set; }
    public bool NationalityHidden { get; set; }
    public string CurrentResidence { get; set; }
    public bool CurrentResidenceInternal { get; set; }
    public bool CurrentResidenceHidden { get; set; }
    public string IDNumber { get; set; }
    public bool IDNumberInternal { get; set; }
    public bool IDNumberHidden { get; set; }
    public DateOnly DateOfBirth { get; set; } //TODO also here, might have to change to string
    public bool DateOfBirthInternal { get;set; }
    public bool DateOfBirthHidden { get; set; }
    public string Gender { get; set; }
    public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
}