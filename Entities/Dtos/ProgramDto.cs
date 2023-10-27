
using Entities.Models;

namespace Entities.Dtos;
/// <summary>
/// DTO class for prgram
/// </summary>
public class ProgramDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] SkillsRequired { get; set; } = Array.Empty<string>();
    public string Benefits { get; set; } = string.Empty;
    public string ApplicationCriteria { get; set; } = string.Empty;
    public AdditionalProgramInformation AdditionalProgramInformation { get; set; } = new AdditionalProgramInformation();
}




/// <summary>
/// DTO class for creating a Program
/// </summary>
public class CreateProgramDto
{
    public string Title { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] SkillsRequired { get; set; } = Array.Empty<string>();
    public string Benefits { get; set; } = string.Empty;
    public string ApplicationCriteria { get; set; } = string.Empty;
    public AdditionalProgramInformation AdditionalProgramInformation { get; set; } = new AdditionalProgramInformation();
}

