using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class BlogService : CrudService<Blog>, IBlogService
{
    public BlogService(ApplicationDbContext context, IWebHostEnvironment environment ) : base(context, environment)
    {
    }

    public async Task<Blog?> GetBySlugAsync(string slug)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(b=>b.Slug==slug);
        return blog;
    }

    public async Task<List<Blog>> GetLastBlogsAsync()
    {
        var blogs = await _context.Blogs.ToListAsync();
        return blogs;
    }

    public async Task<List<Blog>> SearchAsync(string keyword)
    {
        var blogs = await _context.Blogs.ToListAsync();
        return blogs;
    }
}


