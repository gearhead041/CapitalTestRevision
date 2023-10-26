namespace Entities.Models;
/// <summary>
/// Represents Education Section in Profile of an Application Form Template for a Program.
/// </summary>
public class Education
{
    public string School { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string LocationOfStudy { get; set; } = string.Empty;
    public DateOnly StartDate {  get; set; } //TODO change date in case
    public DateOnly EndDate { get; set; }
    public bool CurrentlyStudying { get; set; }
}