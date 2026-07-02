using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IContantRequestService
{
    Task CreateAsync(ContantRequest entity);
    Task<List<ContantRequest>> GetAllAsync();
    Task<ContantRequest?> GetByIdAsync(long id);

    Task MarkAsReadAsync(long id);
    Task DeleteAsync(long id);
}


