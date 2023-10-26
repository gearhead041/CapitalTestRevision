namespace Entities.Models;

/// <summary>
/// Represents the base question type.
/// </summary>
public class Question
{
    public string Type { get; set; } = string.Empty;
    public string QuestionString { get; set; } = string.Empty;
    //TODO valiadation for question type
    public string[]? Choices { get; set; }
    public bool EnableOther { get; set; }
    public int MaxNumberOfChoices { get; set; }
    public bool DisqualifyIfNo { get; set; }
}