using Domain.RepoInterfaces;


namespace DataAccess.Repos
{
    public class UnitOfWork : IUnitOfWOrk
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsyncWithResult(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
