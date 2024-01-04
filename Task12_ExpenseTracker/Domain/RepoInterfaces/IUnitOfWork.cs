namespace Domain.RepoInterfaces
{
    public interface IUnitOfWOrk 
    {
        Task SaveAsync(CancellationToken cancellationToken);
        void Save();
        Task<int> SaveChangesAsyncWithResult(CancellationToken cancellationToken);
    }
}
