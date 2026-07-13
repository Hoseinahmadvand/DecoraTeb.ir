using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.Services.Interfaces.Infrastructure;
using DecoraTeb.ViewModels.Service;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class ServiceService
    : CrudService<Service>, IServiceService
{
  
    private readonly IImageService _imageService;

    public ServiceService(
        ApplicationDbContext context,
        IWebHostEnvironment environment,
        IImageService imageService)
        : base(context, environment)
    {
      
        _imageService = imageService;
    }

    public async Task<List<ServiceVm>> GetAllAsync()
    {
        return await Table<Service>()
            .OrderBy(x => x.SortOrder)
            .Select(x => new ServiceVm
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.Summery,
                Description = x.Description,
             
                Icon = x.Icon,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl,
                Robots = x.Robots
            })
            .ToListAsync();
    }

    public async Task<ServiceVm?> GetByIdAsync(long id)
    {
        return await Table<Service>()
            .Where(x => x.Id == id)
            .Select(x => new ServiceVm
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.Summery,
                Description = x.Description,
               
                Icon = x.Icon,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl,
                Robots = x.Robots
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Service?> GetEntityByIdAsync(long id)
    {
        return await Table<Service>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ServiceVm>> GetActiveAsync()
    {
        return await Table<Service>()
            .Where(x => x.IsActive)
            .OrderBy(x => x.SortOrder)
            .Select(x => new ServiceVm
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.Summery,
                Description = x.Description,

                Icon = x.Icon,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<bool> CreateAsync(CreateServiceVm model)
    {
        var entity = new Service
        {
            Title = model.Title,
            Summery = model.ShortDescription,
            Description = model.Description,
            Icon = model.Icon,
            SortOrder = model.SortOrder,
            IsActive = model.IsActive,

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

    public async Task<bool> UpdateAsync(UpdateServiceVm model)
    {
        var entity = await Table<Service>().FindAsync(model.Id);

        if (entity == null)
            return false;

        entity.Title = model.Title;
        entity.Summery = model.ShortDescription;
        entity.Description = model.Description;
        entity.Icon = model.Icon;
        entity.SortOrder = model.SortOrder;
        entity.IsActive = model.IsActive;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;
        entity.Robots = model.Robots;

        //entity.Image = await _imageService.ReplaceAsync(
        //    model.ImageFile,
        //    entity.Image,
        //    "services",
        //    800,
        //    800);

        UpdateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await Table<Service>().FindAsync(id);

        if (entity == null)
            return false;

        //await _imageService.DeleteAsync(entity.Image, "services");

        DeleteAsync(entity.Id);

        return await SaveChangesAsync();
    }
}


