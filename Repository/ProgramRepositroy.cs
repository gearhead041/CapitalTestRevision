using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ProgramRepositroy : RepositoryBase<Program>, IProgramRepository
{
    public ProgramRepositroy(RepositoryContext context) : base(context)
    {
    }

    public void CreateProgram(Program program)
        => Create(program);

    public async Task<Program?> GetProgram(Guid programId, bool trackChanges)
        => await FindByCondition(p => p.Id == programId, trackChanges).SingleOrDefaultAsync();

    public void UpdateProgram(Program program)
        => Update(program);

    public void DeleteProgram(Program program)
        => Delete(program);
}