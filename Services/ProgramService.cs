using Contracts.Repository;
using Contracts.Services;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;

namespace Services;
/// <summary>
/// Program Service class containing business logic
/// </summary>
internal class ProgramService : IProgramService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper mapper;
    private readonly IFileUploadService fileUploadService;

    public ProgramService(IRepositoryManager repositoryManager, IMapper mapper,
        IFileUploadService fileUploadService)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
        this.fileUploadService = fileUploadService;
    }

    /// <summary>
    /// Creates a Program in the database
    /// </summary>
    /// <param name="programDto"></param>
    /// <returns>ProgramDto of Program created</returns>
    public async Task<ProgramDto> CreateProgram(CreateProgramDto programDto)
    {
        var program = mapper.MapToProgram(programDto);

        repositoryManager.ProgramRepository.CreateProgram(program);
        await repositoryManager.Save();

        return mapper.MapToProgramDto(program);
    }

    /// <summary>
    /// This function gets the program from the database. Also does error handling for program not found.
    /// Throws the rest.
    /// </summary>
    /// <param name="programId">Guid Id of Program</param>
    /// <param name="trackChanges">boolean flag to track changes</param>
    /// <exception cref="CosmosException">An exception from the cosmos db</exception>
    /// <returns>Program with Id <paramref name="programId"/> from the database or null if Program is not found.</returns>
    async Task<Program?> GetProgramFromDb(Guid programId, bool trackChanges)
    {
        try
        {
            var program = await repositoryManager.ProgramRepository.GetProgram(programId, trackChanges);
            //shouldn't be null as cosmos db throws exception if it is
            return program!;
        }
        catch (CosmosException e)
        {
            if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            throw;
        }
    }

    public async Task<ApplicationDto?> GetApplication(Guid programId)
    {
        var program = await GetProgramFromDb(programId, false);
        if (program != null)
        {
            return mapper.MapToApplicationDto(program.ApplicationTemplate);
        }
        return null;
    }

    public async Task<ProgramDto?> GetProgram(Guid programId)
    {
        var program = await GetProgramFromDb(programId, false);
        if (program != null)
        {
            return mapper.MapToProgramDto(program);
        }
        return null;
    }

    public async Task<WorkflowDto?> GetWorkflow(Guid programId)
    {
        var program = await GetProgramFromDb(programId, false);
        if (program != null)
        {
            return mapper.MapToWorkflowDto(program.Workflow);
        }
        return null;
    }

    /// <summary>
    /// Check if File uploaded and File saved are the same
    /// </summary>
    /// <param name="formFile"></param>
    /// <param name="fileUpload"></param>
    /// <returns>rrue or fale</returns>
    private static bool SameFileExists(IFormFile formFile, FileUpload fileUpload)
    {
        return (formFile.Length == fileUpload?.Length) && (formFile.FileName == fileUpload.FileName)
            && (formFile.ContentType == fileUpload.ContentType);
    }


    /// <summary>
    /// Updates Application Form Template of a Program. Also Uploads resume and image files to cloudservice provider
    /// </summary>
    /// <param name="programId"></param>
    /// <param name="applicationDto"></param>
    /// <returns>ApplicationDto of Applicationi Template or null if Program is not found</returns>
    public async Task<ApplicationDto?> UpdateApplication(Guid programId, ApplicationDto applicationDto)
    {
        var oldProgram = await GetProgramFromDb(programId, true);
        if (oldProgram == null)
        {
            return null;
        }
        //some behaviour with cosmos db i don't really get 
        //doesn't allow updates on existing relation, so we just replace the whole thing
        repositoryManager.ProgramRepository.DeleteProgram(oldProgram);
        await repositoryManager.Save();
        var newProgram = oldProgram;
        repositoryManager.ProgramRepository.CreateProgram(newProgram);

        //update application template info
        newProgram.ApplicationTemplate.PersonalInformation = applicationDto.PersonalInformation;
        newProgram.ApplicationTemplate.Profile = applicationDto.Profile;
        newProgram.ApplicationTemplate.AdditionalQuestions = applicationDto.AdditionalQuestions;

        //Upload Image file to cloud service and save url
        var newCoverImageUpload = applicationDto.CoverImageUpload;
        if (newCoverImageUpload != null)
        {
            var oldCoverImageUpload = oldProgram.ApplicationTemplate.CoverImageUpload;
            //if old file upload exists
            if (oldCoverImageUpload != null)
            {
                //if the old file is not the same as new file
                if (!SameFileExists(newCoverImageUpload, oldCoverImageUpload))
                {
                    newProgram.ApplicationTemplate.CoverImageUpload = mapper.MapToFileUpload(newCoverImageUpload);
                    //delete old file first
                    try
                    {
                        await fileUploadService.DeleteFileAsync(oldProgram.ApplicationTemplate.CoverImage);
                        Console.WriteLine($"deleted old file:{oldCoverImageUpload.FileName}");
                    }
                    catch (Exception e)
                    {
                        await Console.Out.WriteLineAsync("deleting image file failed:\n" + e.Message);
                    }
                    //upload file to cloud service and save url
                    try
                    {
                        newProgram.ApplicationTemplate.CoverImage = await fileUploadService.UploadFileAsync(newCoverImageUpload);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("image upload Failed\n" + e.ToString());
                    }
                }
            }
            //if no old file exists
            else
            {
                //upload file
                try
                {
                    newProgram.ApplicationTemplate.CoverImage = await fileUploadService.UploadFileAsync(newCoverImageUpload);
                    newProgram.ApplicationTemplate.CoverImageUpload = mapper.MapToFileUpload(newCoverImageUpload);
                }
                catch (Exception e)
                {
                    Console.WriteLine("image upload Failed\n" + e.ToString());
                }
            }

        }
        await repositoryManager.Save();
        var applicationToReturn = mapper.MapToApplicationDto(newProgram.ApplicationTemplate);
        return applicationToReturn;
    }

    public async Task<ProgramDto?> UpdateProgram(Guid programId, ProgramDto programDto)
    {
        var program = await GetProgramFromDb(programId, true);
        if (program == null)
        {
            return null;
        }
        //manual mapping here. I still think it's better than automapper in this case
        program.Title = programDto.Title;
        program.Summary = programDto.Summary;
        program.Description = programDto.Description ;
        program.SkillsRequired = programDto.SkillsRequired;
        program.Benefits = programDto.Benefits;
        program.ApplicationCriteria = programDto.ApplicationCriteria;
        program.IsPublished = programDto.IsPublished;
        program.AdditionalProgramInformation = programDto.AdditionalProgramInformation;
        await repositoryManager.Save();
        return programDto;
    }

    public async Task<WorkflowDto?> UpdateWorkflow(Guid programId, WorkflowDto workflow)
    {
        var program = await GetProgramFromDb(programId, true);
        if (program == null)
        {
            return null;
        }
        program.Workflow.Stages = (ICollection<Stage>)workflow.Stages;

        await repositoryManager.Save();
        return workflow;
    }
}