namespace Domain.RepoInterfaces
{
    public interface IGenericRepo<T, K> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> FindByConditionAsync(CancellationToken cancellationToken, ISpecification<T> specification = null);
        void RemoveById(K id);
        void Update(T entity);
        Task<int> SaveChangesAsyncWithResult(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
