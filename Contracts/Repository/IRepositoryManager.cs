namespace Contracts.Repository;

public interface IRepositoryManager
{
    IProgramRepository ProgramRepository { get; }
    Task Save();
}