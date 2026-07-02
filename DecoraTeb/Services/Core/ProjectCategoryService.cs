using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;

namespace DecoraTeb.Services.Core;

public class ProjectCategoryService : CrudService<ProjectCategory>, IProjectCategoryService
{
    public ProjectCategoryService(ApplicationDbContext context, IWebHostEnvironment environment, ILogger logger) : base(context, environment, logger)
    {
    }
}


