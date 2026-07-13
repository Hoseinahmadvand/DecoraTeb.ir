
using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels;
using DecoraTeb.ViewModels.Project;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IProjectService : ICrudService<Project>
{
    // CRUD
    Task<List<ProjectVm>> GetAllAsync();

    Task<ProjectVm?> GetByIdAsync(long id);

    Task<Project?> GetEntityByIdAsync(long id);

    Task<bool> CreateAsync(CreateProjectVm model);

    Task<bool> UpdateAsync(UpdateProjectVm model);

    Task<bool> DeleteAsync(long id);
    Task<HomeProjectVm> GetHomeProjectsAsync();
    // Front
    Task<ProjectVm?> GetBySlugAsync(string slug);

    Task<List<ProjectVm>> GetFeaturedProjectsAsync(int take = 6);

    Task<List<ProjectVm>> GetByCategoryAsync(long categoryId);

    Task<List<ProjectVm>> GetLastProjectsAsync(int take = 6);

    // Admin
    Task<FilterProjectVm> FilterAsync(FilterProjectVm filter);


    Task<ProjectDetailVm?> GetDetailAsync(string slug);
}
