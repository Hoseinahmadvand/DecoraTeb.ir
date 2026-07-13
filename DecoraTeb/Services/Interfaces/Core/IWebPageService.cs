using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.WebPage;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IWebPageService
{
    Task<List<WebPageListVm>> GetAllAsync();

    Task<WebPageVm?> GetByIdAsync(long id);

    Task<WebPageVm?> GetByTypeAsync(WebPageType type);

    Task CreateAsync(WebPageVm model);

    Task UpdateAsync(WebPageVm model);

    Task DeleteAsync(long id);

    Task ChangeStatusAsync(long id);
}
