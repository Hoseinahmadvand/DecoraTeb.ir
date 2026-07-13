using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.Service;

namespace DecoraTeb.Services.Interfaces.Core;
public interface IServiceService : ICrudService<Service>
{
    Task<List<ServiceVm>> GetAllAsync();

    Task<ServiceVm?> GetByIdAsync(long id);

    Task<Service?> GetEntityByIdAsync(long id);

    Task<List<ServiceVm>> GetActiveAsync();

    Task<bool> CreateAsync(CreateServiceVm model);

    Task<bool> UpdateAsync(UpdateServiceVm model);

    Task<bool> DeleteAsync(long id);
}


