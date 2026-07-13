using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.Services.Interfaces.Infrastructure;
using DecoraTeb.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class BlogService : CrudService<Blog>, IBlogService
{
    private readonly IImageService _imageService;

    public BlogService(
        ApplicationDbContext context,
        IWebHostEnvironment environment,
        IImageService imageService)
        : base(context, environment)
    {
        _imageService = imageService;
    }

    #region Admin

    public async Task<List<BlogListItemVm>> GetAllAsync()
    {
        return await Table<Blog>()
            .AsNoTracking()
            .OrderByDescending(x => x.CreateAt)
            .Select(x => new BlogListItemVm
            {
                Id = x.Id,
                Slug = x.Slug,
                Summary=x.Summery,
                Author=x.Author,
                ReadingTime=x.ReadingTime,
                Title = x.Title,
                Image = x.Image,
                PublishDate = x.PublishDate,
                IsPublished = x.IsPublished
            })
            .ToListAsync();
    }

    public async Task<BlogDetailsVm?> GetByIdAsync(long id)
    {
        var entity = await base.GetByIdAsync(id);

        return entity == null ? null : ToDetailsVm(entity);
    }

    public async Task<UpdateBlogVm?> GetForEditAsync(long id)
    {
        var entity = await base.GetByIdAsync(id);

        return entity == null ? null : ToUpdateVm(entity);
    }

    public async Task<bool> CreateAsync(CreateBlogVm model)
    {
        var entity = ToEntity(model);

        if (model.ImageFile != null)
            entity.Image = await _imageService.UploadAsync(model.ImageFile, "blogs");

        return await base.CreateEntityAsync(entity);
    }

    public async Task<bool> UpdateAsync(UpdateBlogVm model)
    {
        var entity = await base.GetByIdAsync(model.Id);

        if (entity == null)
            return false;

        Map(model, entity);

        if (model.ImageFile != null)
        {
            entity.Image = await _imageService.ReplaceAsync(
                model.ImageFile,
                entity.Image,
                "blogs");
        }

        return await base.UpdateEntityAsync(entity);
    }

    #endregion

    #region Website

    public async Task<List<BlogListItemVm>> GetLastBlogsAsync(int count = 6)
    {
        return await Table<Blog>()
            .AsNoTracking()
            .Where(x => x.IsPublished)
            .OrderByDescending(x => x.PublishDate)
            .Take(count)
            .Select(x => new BlogListItemVm
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                PublishDate = x.PublishDate,
                IsPublished = x.IsPublished
            })
            .ToListAsync();
    }

    public async Task<List<BlogListItemVm>> SearchAsync(string keyword)
    {
        return await Table<Blog>()
            .AsNoTracking()
            .Where(x => x.Title.Contains(keyword)
                     || x.Summery.Contains(keyword))
            .Select(x => new BlogListItemVm
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                PublishDate = x.PublishDate,
                IsPublished = x.IsPublished
            })
            .ToListAsync();
    }

    public async Task<BlogDetailsVm?> GetBySlugAsync(string slug)
    {
        var entity = await Table<Blog>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == slug && x.IsPublished);

        return entity == null ? null : ToDetailsVm(entity);
    }

    #endregion

    #region Mapper

    private Blog ToEntity(CreateBlogVm model)
    {
        return new Blog
        {
            Title = model.Title,
            Summery = model.Summary,
            Content = model.Content,
            Author = model.Author,
            PublishDate = model.PublishDate,
            ReadingTime = model.ReadingTime,
            BlogCategoryId = model.BlogCategoryId,
            IsPublished = model.IsPublished,

            Slug = model.Slug,
            SeoTitle = model.SeoTitle,
            SeoDescription = model.SeoDescription,
            SeoKeywords = model.SeoKeywords,
            CanonicalUrl = model.CanonicalUrl,
            Robots = model.Robots
        };
    }

    private void Map(UpdateBlogVm model, Blog entity)
    {
        entity.Title = model.Title;
        entity.Summery = model.Summary;
        entity.Content = model.Content;
        entity.Author = model.Author;
        entity.PublishDate = model.PublishDate;
        entity.ReadingTime = model.ReadingTime;
        entity.BlogCategoryId = model.BlogCategoryId;
        entity.IsPublished = model.IsPublished;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;
        entity.Robots = model.Robots;
    }

    private static UpdateBlogVm ToUpdateVm(Blog entity)
    {
        return new UpdateBlogVm
        {
            Id = entity.Id,
            Title = entity.Title,
            Summary = entity.Summery,
            Content = entity.Content,
            Image = entity.Image,
            Author = entity.Author,
            PublishDate = entity.PublishDate,
            ReadingTime = entity.ReadingTime,
            BlogCategoryId = entity.BlogCategoryId,
            IsPublished = entity.IsPublished,

            Slug = entity.Slug,
            SeoTitle = entity.SeoTitle,
            SeoDescription = entity.SeoDescription,
            SeoKeywords = entity.SeoKeywords,
            CanonicalUrl = entity.CanonicalUrl,
            Robots = entity.Robots
        };
    }

    private static BlogDetailsVm ToDetailsVm(Blog entity)
    {
        return new BlogDetailsVm
        {
            Id = entity.Id,
            Title = entity.Title,
            Summary = entity.Summery,
            Content = entity.Content,
            Image = entity.Image,
            Author = entity.Author,
            PublishDate = entity.PublishDate,
            ReadingTime = entity.ReadingTime,
            BlogCategoryId = entity.BlogCategoryId,
            IsPublished = entity.IsPublished,

            Slug = entity.Slug,
            SeoTitle = entity.SeoTitle,
            SeoDescription = entity.SeoDescription,
            SeoKeywords = entity.SeoKeywords,
            CanonicalUrl = entity.CanonicalUrl,
            Robots = entity.Robots
        };
    }

    #endregion
}


