using Domain.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repos
{
    public class GenericRepo<T, K> : IGenericRepo<T, K> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(CancellationToken cancellationToken, ISpecification<T> specification = null)
        {
            var query = _dbSet.AsQueryable();

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            if (specification.AsNoTracking)
            {
                query = query.AsNoTracking(); 
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsyncWithResult(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void RemoveById(K id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
