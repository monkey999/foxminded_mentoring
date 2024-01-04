using System.Linq.Expressions;

namespace A_Domain.Repo_interfaces
{
    public interface IGenericRepo<T, K> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void RemoveById(K id);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task<int> SaveChangesAsyncWithResult();
        Task SaveChangesAsync();
    }
}
