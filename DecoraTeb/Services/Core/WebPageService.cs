using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.WebPage;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class WebPageService : IWebPageService
{
    private readonly ApplicationDbContext _context;

    public WebPageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<WebPageListVm>> GetAllAsync()
    {
        return await _context.WebPages
            .OrderBy(x => x.SortOrder)
            .Select(x => new WebPageListVm
            {
                Id = x.Id,
                Title = x.Title,
                Type = x.Type,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<WebPageVm?> GetByIdAsync(long id)
    {
        return await _context.WebPages
            .Where(x => x.Id == id)
            .Select(x => new WebPageVm
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.ShortDescription,
                Content = x.Content,
                BannerImage = x.BannerImage,
               
                Type = x.Type,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl
            })
            .FirstOrDefaultAsync();
    }

    public async Task<WebPageVm?> GetByTypeAsync(WebPageType type)
    {
        return await _context.WebPages
            .Where(x => x.Type == type)
            .Select(x => new WebPageVm
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.ShortDescription,
                Content = x.Content,
                BannerImage = x.BannerImage,
              
                Type = x.Type,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl
            })
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(WebPageVm model)
    {
        var entity = new WebPage
        {
            Title = model.Title,
            ShortDescription = model.Description,
            Content = model.Content,
            BannerImage = model.BannerImage,
          
            Type = model.Type,
            SortOrder = model.SortOrder,
            IsActive = model.IsActive,

            Slug = model.Slug,
            SeoTitle = model.SeoTitle,
            SeoDescription = model.SeoDescription,
            SeoKeywords = model.SeoKeywords,
            CanonicalUrl = model.CanonicalUrl
        };

        _context.WebPages.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(WebPageVm model)
    {
        var entity = await _context.WebPages.FindAsync(model.Id);

        if (entity == null)
            return;

        entity.Title = model.Title;
        entity.SeoKeywords = model.Description;
        entity.Content = model.Content;
        entity.BannerImage = model.BannerImage;
        
        entity.Type = model.Type;
        entity.SortOrder = model.SortOrder;
        entity.IsActive = model.IsActive;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.WebPages.FindAsync(id);

        if (entity == null)
            return;

        _context.WebPages.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task ChangeStatusAsync(long id)
    {
        var entity = await _context.WebPages.FindAsync(id);

        if (entity == null)
            return;

        entity.IsActive = !entity.IsActive;

        await _context.SaveChangesAsync();
    }
}