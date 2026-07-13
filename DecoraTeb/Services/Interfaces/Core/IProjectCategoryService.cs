using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.ProjectCategory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IProjectCategoryService : ICrudService<ProjectCategory>
{
    Task<List<ProjectCategoryVm>> GetAllAsync();

    Task<ProjectCategoryVm?> GetByIdAsync(long id);

    Task<ProjectCategory?> GetEntityByIdAsync(long id);

    Task<bool> CreateAsync(CreateProjectCategoryVm model);

    Task<bool> UpdateAsync(UpdateProjectCategoryVm model);

    Task<bool> DeleteAsync(long id);

    Task<FilterProjectCategoryVm> FilterAsync(FilterProjectCategoryVm filter);

    Task<List<SelectListItem>> GetSelectListAsync();
}

