using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IProjectService : ICrudService<Project>
{
    Task<List<Project>> GetFeaturedProjectsAsync();
    Task<List<Project>> GetByCategoryAsync(long categoryId);
    Task<Project?> GetBySlugAsync(string slug);
}


