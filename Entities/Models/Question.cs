
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models;

/// <summary>
/// Represents the base question type.
/// </summary>
[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
public class Question : IValidatableObject
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public QuestionType Type { get; set; }
    public string QuestionString { get; set; } = string.Empty;
    public string[]? Choices { get; set; } = null;
    public bool? EnableOther { get; set; } = null;
    public int? MaxNumberOfChoices { get; set; } = null;
    public bool? DisqualifyIfNo { get; set; } = null;

    /// <summary>
    /// Performing validation on question input based on QuestionType
    /// </summary>
    /// <param name = "validationContext" ></ param >
    /// < returns ></ returns >
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Type == QuestionType.YesNo && DisqualifyIfNo == null)
        {
            yield return new ValidationResult("Please provide a value for this field",
                new string[] { nameof(DisqualifyIfNo) });
        }

        if (Type != QuestionType.YesNo && DisqualifyIfNo != null)
        {
            yield return new ValidationResult("Fields not required for selected question type",
                new string[] { nameof(DisqualifyIfNo) });
        }

        if (Type == QuestionType.MultipleChoice || Type == QuestionType.DropDown)
        {
            if (EnableOther == null)
            {
                yield return new ValidationResult("Please provide a value for this field",
                    new string[] { nameof(EnableOther) });
            }

            if (Choices == null)
            {
                yield return new ValidationResult("Please provide values for this field",
                    new string[] { nameof(Choices) });
            }

            if (Type == QuestionType.MultipleChoice && MaxNumberOfChoices == null)
            {
                yield return new ValidationResult("Please provide a value for this field",
                    new string[] { nameof(MaxNumberOfChoices) });
            }
        }

        if ((Type != QuestionType.MultipleChoice || Type != QuestionType.DropDown) &&
            (EnableOther != null || Choices != null || MaxNumberOfChoices != null))
        {
            yield return new ValidationResult("Field not required for selected question type",
                new string[] { nameof(EnableOther), nameof(Choices), nameof(MaxNumberOfChoices) });
        }
    }
}

public enum QuestionType
{
    Paragraph,
    ShortAnswer,
    YesNo,
    DropDown,
    MultipleChoice,
    Date,
    Number,
    FileUpload,
    VideoQuestion
}
