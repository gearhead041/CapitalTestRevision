using Entities.Models;

namespace Contracts.Repository;

public interface IProgramRepository
{
    void CreateProgram(Program program);
    void UpdateProgram(Program program);
    Task<Program?> GetProgram(Guid programId, bool trackChanges);
}