using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepoInterfaces
{
    public interface IGenericRepo<T, K> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void RemoveById(K id);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task<int> SaveChangesAsyncWithResult();
        Task SaveChangesAsync();
    }
}
