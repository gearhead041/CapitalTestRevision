using Contracts.Services;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Services;

public class Mapper : IMapper
{

    /// <summary>
    /// Maps type ApplicationFormTemplate to ApplicationDto
    /// </summary>
    /// <param name="applicationFormTemplate">ApplicationFormTemplate to Map</param>
    /// <returns>An instance of ApplicationDto</returns>
    public ApplicationDto MapToApplicationDto(ApplicationFormTemplate applicationFormTemplate)
         => new()
         {
             CoverImage = applicationFormTemplate.CoverImage,
             PersonalInformation = applicationFormTemplate.PersonalInformation,
             Profile = applicationFormTemplate.Profile,
             AdditionalQuestions = applicationFormTemplate.AdditionalQuestions,
         };

    //Map from an IForm to a FileUpload for saving file metadata in the database
    public FileUpload MapToFileUpload(IFormFile file)
        => new()
        {
            FileName = file.FileName,
            ContentType = file.ContentType,
            Length = file.Length,
        };

    /// <summary>
    /// Maps type CreateProgramDto to Program
    /// </summary>
    /// <param name="programDto">ProgramDto to Map</param>
    /// <returns>An instance of Program</returns>
    public Program MapToProgram(CreateProgramDto programDto)
        => new()
        {
            Title = programDto.Title!,
            IsPublished = programDto.IsPublished,
            Summary = programDto.Summary!,
            Description = programDto.Description!,
            Benefits = programDto.Benefits!,
            ApplicationCriteria = programDto.ApplicationCriteria!,
        };

    /// <summary>
    /// Maps an instance of Program to ProgramDto
    /// </summary>
    /// <param name="program">Program to Map</param>
    /// <returns>An instance of ProgramDto</returns>
    public ProgramDto MapToProgramDto(Program program)
        => new()
        {
            Id = program.Id,
            Title = program.Title,
            IsPublished = program.IsPublished,
            Summary = program.Summary,
            Description = program.Description,
            SkillsRequired = program.SkillsRequired,
            Benefits = program.Benefits,
            ApplicationCriteria = program.ApplicationCriteria,
        };

    /// <summary>
    /// Maps an instance of Workflow to WorkflowDto
    /// </summary>
    /// <param name="workflow">workflow to Map</param>
    /// <returns>An instance of WorkflowDto</returns>
    public WorkflowDto MapToWorkflowDto(Workflow workflow)
        => new()
        {
            Stages = workflow.Stages,
        };
}
