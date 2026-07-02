using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Base;

public class CrudService<TEntity> : BaseService, ICrudService<TEntity>
    where TEntity : BaseEntity
{
    public CrudService(ApplicationDbContext context,
                       IWebHostEnvironment environment,
                       ILogger logger) 
        : base(context, environment, logger)
    {
    }
    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(long id)
    {
        return await _context.Set<TEntity>()
            .FindAsync(id);
    }


    public Task<bool> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> DeleteAsync(long id)
    {
       var entity =await GetByIdAsync(id);
        if (entity == null) 
            return false;
        Table<TEntity>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> ExistAsync(long id)
    {
        return await Table<TEntity>().AnyAsync(x => x.Id == id);
    }

    public Task<bool> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
