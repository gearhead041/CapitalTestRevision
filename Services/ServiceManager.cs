using Contracts.Repository;
using Contracts.Services;

namespace Services;

/// <summary>
/// Service manager for API
/// </summary>
public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProgramService> programService;
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IFileUploadService fileUploadService)
    {
        programService = new Lazy<IProgramService>(() => new ProgramService(repositoryManager, mapper, fileUploadService));
    }

    public IProgramService ProgramService => programService.Value;
}