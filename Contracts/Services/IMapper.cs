
using Entities.Dtos;
using Entities.Models;

namespace Contracts.Services;

public interface IMapper
{
    ProgramDto GetProgramDto(Program program);
    Program GetProgram(CreateProgramDto programdto);
    WorkflowDto GetWorkflowDto(Workflow workflow);
    ApplicationDto GetApplicationDto(ApplicationFormTemplate applicationFormTemplate);
}
