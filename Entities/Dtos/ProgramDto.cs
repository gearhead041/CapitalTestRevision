
namespace Entities.Dtos;

public class PreviewDto
{
    public string ProgramTitle { get; set; }
    public string Image {  get; set; }
    public bool IsPublished { get; set; }
    public string ProgramSummary { get; set; }
    public string ProgramDescription { get; set; }
    public string[] ProgramSKilsRequired { get; set; }
    public string ProgramBenefits { get; set; }
    public string ApplicationCriteria { get; set; }
}
