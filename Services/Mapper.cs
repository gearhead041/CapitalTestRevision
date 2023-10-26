using Contracts.Services;
using Entities.Dtos;
using Entities.Models;

namespace Services;

public class Mapper : IMapper
{

    /// <summary>
    /// Maps type ApplicationFormTemplate to ApplicationDto
    /// </summary>
    /// <param name="applicationFormTemplate">ApplicationFormTemplate to Map</param>
    /// <returns>An instance of ApplicationDto</returns>
    public ApplicationDto GetApplicationDto(ApplicationFormTemplate applicationFormTemplate)
         => new ApplicationDto
         {
             CoverImage = applicationFormTemplate.CoverImage,
             PersonalInformation = applicationFormTemplate.PersonalInformation,
             Profile = applicationFormTemplate.Profile,
             AdditionalQuestions = applicationFormTemplate.AdditionalQuestions,
         };


    /// <summary>
    /// Maps type CreateProgramDto to Program
    /// </summary>
    /// <param name="programDto">ProgramDto to Map</param>
    /// <returns>An instance of Program</returns>
    public Program GetProgram(CreateProgramDto programDto)
        => new Program
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
    public ProgramDto GetProgramDto(Program program)
        => new ProgramDto
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
    public WorkflowDto GetWorkflowDto(Workflow workflow)
        => new WorkflowDto
        {
            Stages = workflow.Stages,
        };
}
