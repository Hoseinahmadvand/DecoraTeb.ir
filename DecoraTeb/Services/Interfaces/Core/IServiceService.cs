using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;
public interface IServiceService : ICrudService<Service>
{
    Task<List<Service>> GetActiveServicesAsync();
}


