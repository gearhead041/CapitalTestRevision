namespace Entities.Models;

/// <summary>
/// Represents a Program in the Database.
/// </summary>
public class Program
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] SkillsRequired { get; set; } = Array.Empty<string>();
    public string Benefits { get; set; } = string.Empty;
    public string ApplicationCriteria { get; set; } = string.Empty;
    public AdditionalProgramInformation AdditionalProgramInformation { get; set; } = new AdditionalProgramInformation();
    public ApplicationFormTemplate ApplicationTemplate { get; set; } = new ApplicationFormTemplate();
    public Workflow Workflow { get; set; } = new Workflow();
    public bool IsPublished { get; set; }
}
