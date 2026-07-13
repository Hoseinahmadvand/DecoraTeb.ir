using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.Faq;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IFaqService : ICrudService<FAQ>
{
    Task<List<FaqVm>> GetAllAsync();

    Task<FaqVm?> GetByIdAsync(long id);

    Task<FAQ?> GetEntityByIdAsync(long id);

    Task<List<FaqVm>> GetActiveAsync();

    Task<bool> CreateAsync(CreateFaqVm model);

    Task<bool> UpdateAsync(UpdateFaqVm model);

    Task<bool> DeleteAsync(long id);
}

