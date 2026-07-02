using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Base;

public abstract class BaseService
{
    protected readonly ApplicationDbContext _context;
    protected readonly IWebHostEnvironment _environment;
   // protected readonly ILogger _logger;

    protected BaseService(ApplicationDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
       ;
    }
    protected async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    protected IQueryable<T> Query<T>() where T : class
    {
        return _context.Set<T>().AsQueryable();
    }
    protected DbSet<T> Set<T>() where T : class
    {
        return _context.Set<T>();
    }
    protected DbSet<T> Table<T>() where T : BaseEntity
    {
        return _context.Set<T>();
    }


}
