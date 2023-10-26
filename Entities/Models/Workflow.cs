namespace Entities.Models;

/// <summary>
/// This represents the workflow for a program in the database
/// </summary>
public class Workflow
{
    public IEnumerable<Stage> Stages { get; set; } = Enumerable.Empty<Stage>();
}


/// <summary>
/// Represents the base class for stages in a workflow
/// </summary>
public abstract class Stage
{
    public string StageName { get; set; }
    public bool ShowStage { get; set; }
}

public class Shortlisting : Stage
{ 

}

public class VideoInterviewStage : Stage
{
    public string VideoInterviewQuestion { get; set; }
    public string AdditionalInformation { get; set; }
    public int MaxDurationOfVideo { get; set;}
    public string DurationUnit { get; set; }
    public int DeadlineForSubmission { get; set; }
}
