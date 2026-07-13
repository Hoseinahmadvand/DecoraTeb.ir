using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.ProjectCategory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class ProjectCategoryService : CrudService<ProjectCategory>, IProjectCategoryService
{
    public ProjectCategoryService(ApplicationDbContext context, IWebHostEnvironment environment) : base(context, environment)
    {
    }

    public async Task<bool> CreateAsync(CreateProjectCategoryVm model)
    {
        var entity = new ProjectCategory
        {
            Title = model.Title,
            SortOrder = model.SortOrder,

            Slug = model.Slug,
            SeoTitle = model.SeoTitle,
            SeoDescription = model.SeoDescription,
            SeoKeywords = model.SeoKeywords,
            CanonicalUrl = model.CanonicalUrl,
            Robots = model.Robots
        };

        await CreateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<FilterProjectCategoryVm> FilterAsync(FilterProjectCategoryVm filter)
    {
        var query = Table<ProjectCategory>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(filter.Title))
            query = query.Where(x => x.Title.Contains(filter.Title));

        filter.TotalCount = await query.CountAsync();

        filter.Categories = await query
            .OrderBy(x => x.SortOrder)
            .Skip((filter.PageNumber - 1) * filter.Take)
            .Take(filter.Take)
            .Select(x => new ProjectCategoryVm
            {
                Id = x.Id,
                Title = x.Title,
                SortOrder = x.SortOrder
            })
            .ToListAsync();

        return filter;
    }

    public async Task<ProjectCategory?> GetEntityByIdAsync(long id)
    {
        return await Table<ProjectCategory>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<SelectListItem>> GetSelectListAsync()
    {
        return await Table<ProjectCategory>()
            .AsNoTracking()
            .OrderBy(x => x.SortOrder)
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            })
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(UpdateProjectCategoryVm model)
    {
        var entity = await GetEntityByIdAsync(model.Id);

        if (entity == null)
            return false;

        entity.Title = model.Title;
        entity.SortOrder = model.SortOrder;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;
        entity.Robots = model.Robots;

        UpdateAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<List<ProjectCategoryVm>> GetAllAsync()
    {
        return await Table<ProjectCategory>()
            .AsNoTracking()
            .OrderBy(x => x.SortOrder)
            .Select(x => new ProjectCategoryVm
            {
                Id = x.Id,
                Title = x.Title,
                SortOrder = x.SortOrder,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl,
                Robots = x.Robots
            })
            .ToListAsync();
    }

    public async Task<ProjectCategoryVm?> GetByIdAsync(long id)
    {
        return await Table<ProjectCategory>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProjectCategoryVm
            {
                Id = x.Id,
                Title = x.Title,
                SortOrder = x.SortOrder,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl,
                Robots = x.Robots
            })
            .FirstOrDefaultAsync();
    }
}


