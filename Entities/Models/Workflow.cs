namespace Entities.Models;

/// <summary>
/// This represents the workflow for a program in the database
/// </summary>
public class Workflow
{
    public ICollection<Stage> Stages { get; set; } = new List<Stage>();
}


/// <summary>
/// Represents the base class for stages in a workflow
/// </summary>
public class Stage
{
    public string StageName { get; set; } = string.Empty;
    //TODO validation for stage type
    public bool ShowStage { get; set; }
    public string? VideoInterviewQuestion { get; set; }
    public string? AdditionalInformation { get; set; }
    public int MaxDurationOfVideo { get; set;}
    public string? DurationUnit { get; set; }
    public int DeadlineForSubmission { get; set; }
}
