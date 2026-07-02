using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IBlogService : ICrudService<Blog>
{
    Task<List<Blog>> GetLastBlogsAsync();
    Task<List<Blog>> SearchAsync(string keyword);
    Task<Blog?> GetBySlugAsync(string slug);
}


