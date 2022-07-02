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

        //public BaseDataAccess()
        //{
        //}

        //public async Task AddAsync(T entity, CancellationToken cancellationToken)
        //{
        //    await _appContext.Set<T>().AddAsync(entity, cancellationToken);
        //    await _appContext.SaveChangesAsync(cancellationToken);
        //}
        //public async Task AddRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken)
        //{
        //    await _appContext.Set<T>().AddRangeAsync(entity, cancellationToken);
        //    await _appContext.SaveChangesAsync(cancellationToken);
        //}

        //public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        //{
        //    T existing = await _appContext.Set<T>().FindAsync(entity);
        //    if (existing != null) _appContext.Set<T>().Remove(existing);
        //    await _appContext.SaveChangesAsync(cancellationToken);
        //}

        //public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        //{
        //    return await _appContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync<T>();
        //}

        //public async Task<IEnumerable<T>> GetAsync()
        //{
        //    return await _appContext.Set<T>().AsNoTracking().ToListAsync<T>();
        //}

        //public async Task Update(T entity, CancellationToken cancellationToken)
        //{
        //    _appContext.Entry(entity).State = EntityState.Modified;
        //    _appContext.Set<T>().Attach(entity);
        //    await _appContext.SaveChangesAsync(cancellationToken);
        //}
    }
}

