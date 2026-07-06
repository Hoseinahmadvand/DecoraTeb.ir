using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.BlogCategory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IBlogCategoryService
{
    Task<List<BlogCategoryListItemVm>> GetAllAsync();

    Task<CreateOrUpdateBlogCategoryVm?> GetByIdAsync(long id);

    Task<bool> CreateAsync(CreateOrUpdateBlogCategoryVm model);

    Task<bool> UpdateAsync(CreateOrUpdateBlogCategoryVm model);

    Task<bool> DeleteAsync(long id);

    Task<List<SelectListItem>> GetSelectListAsync();
}


