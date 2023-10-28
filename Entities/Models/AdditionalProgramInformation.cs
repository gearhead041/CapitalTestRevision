namespace Entities.Models;

/// <summary>
/// Represents the Additional Program Information section in the Program. 
/// </summary>
public class AdditionalProgramInformation
{
    public string ProgramType { get; set; } = string.Empty;
    public DateTime ProgramStart { get; set; }
    public DateTime ApplicationOpen { get; set; }
    public DateTime ApplicationClose { get; set; }
    public string Duration { get; set; } = string.Empty;
    public string ProgramLocationString { get; set; } = string.Empty;
    public bool FullyRemote { get; set; } // defaults to false
    public string MinQualifications { get; set; } = string.Empty;
    public int MaxApplications { get; set; }
}