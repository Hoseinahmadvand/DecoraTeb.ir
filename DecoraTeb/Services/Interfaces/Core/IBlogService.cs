using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.Blog;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IBlogService
{
    Task<List<BlogListItemVm>> GetAllAsync();

    Task<BlogDetailVm?> GetByIdAsync(long id);

    Task<UpdateBlogVm?> GetForEditAsync(long id);

    Task<bool> CreateAsync(CreateBlogVm model);

    Task<bool> UpdateAsync(UpdateBlogVm model);

    Task<bool> DeleteAsync(long id);

    Task<List<BlogListItemVm>> GetLastBlogsAsync(int count = 6);

    Task<List<BlogListItemVm>> SearchAsync(string keyword);

    Task<BlogDetailVm?> GetBySlugAsync(string slug);

    Task<BlogDetailVm?> GetDetailAsync(string slug);
}


