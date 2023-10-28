using Microsoft.AspNetCore.Mvc;

namespace Entities.Models;

/// <summary>
/// Represents the profile section in the application form template for a program.
/// </summary>
public class Profile
{
    public ICollection<Forms>? ProfileForms { get; set; }
}

[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
public class Forms
{
    public string Name { get; set; } = string.Empty;
    public bool FormMandatory { get; set; }
    public bool FormVisible { get; set; }
    public ICollection<Question>? Fields { get; set; }
}