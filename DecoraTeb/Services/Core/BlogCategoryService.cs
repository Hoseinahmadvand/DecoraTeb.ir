using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.BlogCategory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class BlogCategoryService : CrudService<BlogCategory>, IBlogCategoryService
{
    public BlogCategoryService(
        ApplicationDbContext context,
        IWebHostEnvironment environment)
        : base(context, environment)
    {
    }

    public async Task<List<BlogCategoryListItemVm>> GetAllAsync()
    {
       var result= await Table<BlogCategory>()
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Select(x => new BlogCategoryListItemVm
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug
            })
            .ToListAsync();

        return result;
    }

    public async Task<CreateOrUpdateBlogCategoryVm?> GetByIdAsync(long id)
    {
        var entity = await base.GetByIdAsync(id);

        if (entity == null)
            return null;

        return ToVm(entity);
    }

    public async Task<bool> CreateAsync(CreateOrUpdateBlogCategoryVm model)
    {
        var entity = ToEntity(model);

        return await base.CreateEntityAsync(entity);
    }

    public async Task<bool> UpdateAsync(CreateOrUpdateBlogCategoryVm model)
    {
        var entity = await base.GetByIdAsync(model.Id);

        if (entity == null)
            return false;

        Map(model, entity);

        return await base.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await base.DeleteAsync(id);
    }

    #region Mapper

    private static BlogCategory ToEntity(CreateOrUpdateBlogCategoryVm model)
    {
        return new BlogCategory
        {
            Title = model.Title,

            Slug = model.Slug,
            SeoTitle = model.SeoTitle,
            SeoDescription = model.SeoDescription,
            SeoKeywords = model.SeoKeywords,
            CanonicalUrl = model.CanonicalUrl,
            Robots = model.Robots
        };
    }

    private static void Map(CreateOrUpdateBlogCategoryVm model, BlogCategory entity)
    {
        entity.Title = model.Title;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;
        entity.Robots = model.Robots;
    }

    private static CreateOrUpdateBlogCategoryVm ToVm(BlogCategory entity)
    {
        return new CreateOrUpdateBlogCategoryVm
        {
            Id = entity.Id,
            Title = entity.Title,


            Slug = entity.Slug,
            SeoTitle = entity.SeoTitle,
            SeoDescription = entity.SeoDescription,
            SeoKeywords = entity.SeoKeywords,
            CanonicalUrl = entity.CanonicalUrl,
            Robots = entity.Robots
        };
    }
    public async Task<List<SelectListItem>> GetSelectListAsync()
    {
        return await Table<BlogCategory>()
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            })
            .ToListAsync();
    }
    #endregion
}