
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Contracts.Services;

public interface IMapper
{
    ProgramDto MapToProgramDto(Program program);
    Program MapToProgram(CreateProgramDto programdto);
    WorkflowDto MapToWorkflowDto(Workflow workflow);
    ApplicationDto MapToApplicationDto(ApplicationFormTemplate applicationFormTemplate);
    FileUpload MapToFileUpload(IFormFile file);
}
