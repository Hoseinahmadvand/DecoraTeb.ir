using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;

public interface ICrudService<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(long id);
    
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(long id);
    Task<bool> ExistAsync(long id);
}


