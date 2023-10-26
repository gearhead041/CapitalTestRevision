
using Entities.Models;

namespace Entities.Dtos;
/// <summary>
/// DTO class for prgram
/// </summary>
public class ProgramDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public bool IsPublished { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public string[]? SkillsRequired { get; set; }
    public string? Benefits { get; set; } = string.Empty;
    public string? ApplicationCriteria { get; set; } = string.Empty;
    public AdditionalProgramInformation? AdditionalProgramInformation { get; set; }
}




/// <summary>
/// DTO class for creating a Program
/// </summary>
public class CreateProgramDto
{
    public string? Title { get; set; }
    public bool IsPublished { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }           
    public string[] Required { get; set; } = Array.Empty<string>();
    public string? Benefits { get; set; }
    public string? ApplicationCriteria { get; set; }
}

