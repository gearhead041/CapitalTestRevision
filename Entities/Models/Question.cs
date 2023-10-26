namespace Entities.Models;

/// <summary>
/// Represents the base question type.
/// </summary>
public class Question
{
    public string Type { get; set; } = string.Empty;
    public string QuestionString { get; set; } = string.Empty;
}

/// <summary>
/// Represent Paragraph type question.
/// </summary>
public class ParagraphQuestion : Question
{

}

/// <summary>
/// Represent the Dropdown question type.
/// </summary>
public class DropdownQuestion: Question
{
    public string[] Choices { get; set; } = Array.Empty<string>();
    public bool EnableOther { get; set; }
}

/// <summary>
/// Represents multiple choice question type.
/// </summary>
public class MultipleChoiceQuestion : Question
{
    public string[] Choices { get; set; } = Array.Empty<string>();
    public bool EnableOther { get; set; }
    public int MaxNumberOfChoices { get; set; }
}

/// <summary>
/// Represents the yes or no question type.
/// </summary>
public class YesOrNoQuestion : Question
{
    public bool DisqualifyIfNo { get; set; }
}