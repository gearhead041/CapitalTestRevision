namespace Entities.Models;

/// <summary>
/// Represents a Program in the Database.
/// </summary>
public class Program
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string[] SkillsRequired { get; set; } = Array.Empty<string>();
    public string Benefits { get; set; }
    public string ApplicationCriteria { get; set; } 
    public AdditionalProgramInformation AdditionalProgramInformation { get; set; } = new AdditionalProgramInformation();
    public ApplicationFormTemplate ApplicationTemplate { get; set; } = new ApplicationFormTemplate();
    public Workflow Workflow { get; set; } = new Workflow();
    public bool IsPublished { get; set; }
}
