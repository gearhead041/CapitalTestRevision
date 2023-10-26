namespace Entities.Models;
/// <summary>
/// Represents Experience Section in Profile of an Application Form Template for a Program.
/// </summary>
public class Experience
{
    public string Company { get; set; } = string.Empty; 
    public string Title { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; } //TODO also maybe change
    public bool CurrentlyWorkingHere { get; set; }
}