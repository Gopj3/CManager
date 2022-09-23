using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.DataAccess
{
    public class BaseDataAccess<T> where T : class
    {
        protected readonly ApplicationDbContext _appContext;

        public BaseDataAccess(ApplicationDbContext context)
        {
            _appContext = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _appContext.Set<T>().AddAsync(entity, cancellationToken);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken)
        {
            await _appContext.Set<T>().AddRangeAsync(entity, cancellationToken);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            var existing = await _appContext.Set<T>().FindAsync(entity, cancellationToken);
            if (existing != null) _appContext.Set<T>().Remove(existing);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await _appContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _appContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetSingleByPredicate(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await _appContext.Set<T>().Where(predicate).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
            _appContext.Set<T>().Attach(entity);
            await _appContext.SaveChangesAsync(cancellationToken);
        }
    }
}