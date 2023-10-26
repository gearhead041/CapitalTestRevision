using Contracts.Repository;
using Contracts.Services;
using Entities.Dtos;
using Entities.Models;

namespace Services;

internal class ProgramService : IProgramService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper mapper;

    public ProgramService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }

    public async Task<ProgramDto> CreateProgram(CreateProgramDto programDto)
    {
        var program = mapper.GetProgram(programDto);

        repositoryManager.ProgramRepository.CreateProgram(program);
        await repositoryManager.Save();

        return mapper.GetProgramDto(program);
    }

    public async Task<ApplicationDto?> GetApplication(Guid programId)
    {
        var program = await repositoryManager.ProgramRepository.GetProgram(programId, false);
        if (program == null)
        {
            return null;
        }

        return mapper.GetApplicationDto(program.ApplicationTemplate);
    }

    public async Task<ProgramDto?> GetProgram(Guid programId)
    {
        var program = await repositoryManager.ProgramRepository.GetProgram(programId, false);
        if (program == null)
        {
            return null;
        }

        return mapper.GetProgramDto(program);
    }

    public async Task<WorkflowDto?> GetWorkflow(Guid programId)
    {
        var program = await repositoryManager.ProgramRepository.GetProgram(programId, false);
        if (program == null)
        {
            return null;
        }

        return mapper.GetWorkflowDto(program.Workflow);
    }

    public async Task<ApplicationDto?> UpdateApplication(Guid programId, ApplicationDto applicationDto)
    {
        var program = await repositoryManager.ProgramRepository.GetProgram(programId, true);
        if (program == null)
        {
            return null;
        }
        program.ApplicationTemplate = new()
        {
            CoverImage = applicationDto.CoverImage ?? program.ApplicationTemplate.CoverImage,
            PersonalInformation = applicationDto.PersonalInformation?? program.ApplicationTemplate.PersonalInformation,
            Profile = applicationDto.Profile ?? program.ApplicationTemplate.Profile,
            AdditionalQuestions = applicationDto.AdditionalQuestions ?? program.ApplicationTemplate.AdditionalQuestions,
        };
        await repositoryManager.Save();
        return applicationDto;
    }

    public async Task<ProgramDto?> UpdateProgram(Guid programId, ProgramDto programDto)
    {
        var program = await repositoryManager.ProgramRepository.GetProgram(programId, true);
        if (program == null)
        {
            return null;
        }
        program.Title = programDto.Title ?? program.Title;
        program.Summary = programDto.Summary ?? program.Summary;
        program.Description = programDto.Description?? program.Description;
        program.SkillsRequired = programDto.SkillsRequired?? program.SkillsRequired;
        program.Benefits = programDto.Benefits ?? program.Benefits;
        program.ApplicationCriteria = programDto.ApplicationCriteria ?? program.ApplicationCriteria;
        program.IsPublished = programDto.IsPublished;
        program.AdditionalProgramInformation = programDto.AdditionalProgramInformation?? program.AdditionalProgramInformation;
        await repositoryManager.Save();
        return programDto;
    }

    public async Task<WorkflowDto?> UpdateWorkflow(Guid programId, WorkflowDto workflow)
    {
        var program = await repositoryManager.ProgramRepository.GetProgram(programId, true);
        if (program == null)
        {
            return null;
        }
        program.Workflow.Stages = workflow.Stages;
        await repositoryManager.Save();
        return workflow;
    }
}