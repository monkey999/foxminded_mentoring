using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace B_DataAccess
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : class
    {
        protected readonly UniversityDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(UniversityDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(_dbSet);
        }

        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(_dbSet.Where(expression));
        }

        public async Task<int> SaveChangesAsyncWithResult()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void RemoveById(K id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
