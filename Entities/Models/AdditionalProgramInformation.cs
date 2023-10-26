namespace Entities.Models;

/// <summary>
/// Represents the Additional Program Information section in the Program. 
/// </summary>
public class AdditionalProgramInformation
{
    public string ProgramType { get; set; }
    public DateOnly ProgramStart { get; set; } //TODO may have to fix later. change to string to work
    public DateOnly ApplicationOpen { get; set; }
    public DateOnly ApplicationClose { get; set;}
    public string Duration { get; set;}
    public string? ProgramLocationString { get; set;} //can be null
    public bool FullyRemote { get; set;} // defaults to false
    public string MinQualifications { get; set;}
    public int MaxApplications { get; set;}
}