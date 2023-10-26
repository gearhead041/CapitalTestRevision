
namespace Entities.Dtos;

public class WorkflowDto
{
    public IEnumerable<StageDto> Stages { get; set; } = Enumerable.Empty<StageDto>();
}


/// <summary>
/// Represents the base class for stages in a workflow
/// </summary>
public abstract class StageDto
{
    public string StageName { get; set; }
    public bool ShowStage { get; set; }
}

public class ShortlistingDto : StageDto
{

}

public class VideoInterviewStage : StageDto
{
    public string VideoInterviewQuestion { get; set; }
    public string AdditionalInformation { get; set; }
    public int MaxDurationOfVideo { get; set; }
    public string DurationUnit { get; set; }
    public int DeadlineForSubmission { get; set; }
}