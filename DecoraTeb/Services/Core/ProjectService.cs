using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class ProjectService
    : CrudService<Project>, IProjectService
{
    public ProjectService(
        ApplicationDbContext context,
        IWebHostEnvironment environment
       ) 
        : base(context, environment)
    {
    }

    public async Task<List<Project>> GetByCategoryAsync(long categoryId)
    {
        var projects= _context.Projects.Where(p=>p.ProjectCategoryId==categoryId).ToListAsync();

        return await projects;
    }

    public async Task<Project?> GetBySlugAsync(string slug)
    {
       var project= _context.Projects.FirstOrDefault(p=>p.Slug==slug);
         if (project == null)
            return null;
         return project;
    }

    public Task<List<Project>> GetFeaturedProjectsAsync()
    {
        throw new NotImplementedException();
    }
}


