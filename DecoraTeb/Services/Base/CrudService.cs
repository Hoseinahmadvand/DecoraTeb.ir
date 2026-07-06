using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Base;

public class CrudService<TEntity> : BaseService, ICrudService<TEntity>
    where TEntity : BaseEntity
{
    public CrudService(ApplicationDbContext context,
                       IWebHostEnvironment environment
                       ) 
        : base(context, environment)
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

    protected virtual async Task<bool> CreateEntityAsync(TEntity entity)
    {
        await Table<TEntity>().AddAsync(entity);
        return await SaveChangesAsync();
    }

    protected virtual async Task<bool> UpdateEntityAsync(TEntity entity)
    {
        Table<TEntity>().Update(entity);
        return await SaveChangesAsync();
    }
    protected async Task<bool> SaveChangesAsync()
      => await _context.SaveChangesAsync() > 0;

    public Task<bool> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
