using Entities.Dtos;

namespace Contracts.Services;

/// <summary>
/// Interface for the program Service, deals with creating, reading and updating programs. 
/// </summary>
public interface IProgramService
{
    Task<ProgramDto> CreateProgram(CreateProgramDto programDto);
    Task<ProgramDto> GetProgram(Guid programId);
    Task<ProgramDto> UpdateProgram(Guid programId);
    Task<PreviewDto> GetPreview(Guid programId);
    Task<ApplicationDto> GetApplication(Guid programId);
    Task<ApplicationDto> UpdateApplication(Guid applicationId);
    Task<WorkflowDto> GetWorkflow(Guid programId);
    Task<WorkflowDto> UpdateWorkflow(Guid programId);
}