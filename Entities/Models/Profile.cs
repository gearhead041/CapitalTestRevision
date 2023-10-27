namespace Entities.Models;

/// <summary>
/// Represents the profile section in the application form template for a program.
/// </summary>
public class Profile
{
    public ICollection<Forms> ProfileForms { get; set; } = new List<Forms>();
}

public class Forms
{
    public bool FormMandatory { get; set; }
    public bool FormVisible { get; set; }
    public ICollection<Question> Fields { get; set; } = new List<Question>();
}