namespace Entities.Models;
/// <summary>
/// Represents Experience Section in Profile of an Application Form Template for a Program.
/// </summary>
public class Experience
{
    public string Company {  get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; } //TODO also maybe change
    public bool CurrentlyWorkingHere { get; set; }
}