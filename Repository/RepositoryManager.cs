
using Contracts.Repository;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext context;
        private readonly Lazy<IProgramRepository> programRepository;
        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
            programRepository = new Lazy<IProgramRepository>(() => new ProgramRepositroy(context));

        }
        public IProgramRepository ProgramRepository => programRepository.Value;

        public async Task Save()
        {
            await context.Database.EnsureCreatedAsync();
            await context.SaveChangesAsync();
        }
    }
}