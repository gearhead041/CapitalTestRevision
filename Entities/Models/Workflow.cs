using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models;

/// <summary>
/// This represents the workflow for a program in the database
/// </summary>
public class Workflow
{
    public ICollection<Stage> Stages { get; set; } = new List<Stage>();
}


/// <summary>
/// Represents the base class for stages in a workflow.
/// Validation done based on stagetype.
/// </summary>
public class Stage : IValidatableObject
{
    /// <summary>
    /// This is converted from string representations to an enum type.
    /// Int in this case
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StageType StageType { get; set; }
    public string StageName { get; set; } = string.Empty;
    public bool ShowStage { get; set; }
    //Setting 
    public string? VideoInterviewQuestion { get; set; }
    public string? AdditionalInformation { get; set; }
    public int? MaxDurationOfVideo { get; set; }
    public string? DurationUnit { get; set; } = null;
    public int? DeadlineForSubmission { get; set; } = null;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StageType == StageType.VideoInterview && (VideoInterviewQuestion == null || AdditionalInformation == null ||
            MaxDurationOfVideo == null || DurationUnit == null || DeadlineForSubmission == null))
        {
            yield return new ValidationResult("Please enter values for the required fields",
                new string[] {nameof(VideoInterviewQuestion), nameof(AdditionalInformation),nameof(MaxDurationOfVideo),
                nameof(DurationUnit), nameof(DeadlineForSubmission)});
        }

        if (StageType != StageType.VideoInterview && (VideoInterviewQuestion != null || AdditionalInformation != null ||
            MaxDurationOfVideo != null || DurationUnit != null || DeadlineForSubmission != null))
        {
            yield return new ValidationResult("These fields are not required for the stage type selected",
                new string[] {nameof(VideoInterviewQuestion), nameof(AdditionalInformation),nameof(MaxDurationOfVideo),
                nameof(DurationUnit), nameof(DeadlineForSubmission)});
        }
    }
}

public enum StageType
{
    Shortlisting,
    VideoInterview,
    Placment
}
