using System.Linq.Expressions;
using ClassLibraryApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class Repository<T> :IRepository<T> where T : class , new()
{
    private readonly MeetMeContext _meetMeContext;

    public Repository(MeetMeContext meetMeContext)
    {
        _meetMeContext = meetMeContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _meetMeContext.Set<T>().AsNoTracking().ToListAsync();
        
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _meetMeContext.Set<T>().FindAsync(id);
     
    }

    public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
       return await _meetMeContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
      
    }

    public async Task CreateAsync(T entity)
    {
        _meetMeContext.Set<T>().Add(entity);
        await _meetMeContext.SaveChangesAsync();

    }

    public async Task UpdateAsync(T entity)
    {
        _meetMeContext.Set<T>().Update(entity); 
        await _meetMeContext.SaveChangesAsync();
        throw new NotImplementedException();
    }

    public async Task Remove(T entity)
    {
        _meetMeContext.Set<T>().Remove(entity);
        await _meetMeContext.SaveChangesAsync();
    }
}