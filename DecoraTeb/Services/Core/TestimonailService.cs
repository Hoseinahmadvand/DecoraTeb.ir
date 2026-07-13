using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.Services.Interfaces.Infrastructure;
using DecoraTeb.ViewModels.Testimonial;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;



public class TestimonialService
    : CrudService<Testimonial>, ITestimonialService
{
   
    private readonly IImageService _imageService;

    public TestimonialService(
        ApplicationDbContext context,
        IWebHostEnvironment environment,
        IImageService imageService)
        : base(context, environment)
    {
      
        _imageService = imageService;
    }

    public async Task<List<TestimonialVm>> GetAllAsync()
    {
        return await Table<Testimonial>()
            .OrderBy(x => x.OrderSort)
            .Select(x => new TestimonialVm
            {
                Id = x.Id,
                FullName = x.FullName,
                JobTitle = x.jobTitle,
                Comment = x.Comment,
                Image = x.Image,
                Rate = x.Rate,
                SortOrder = x.OrderSort,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<TestimonialVm?> GetByIdAsync(long id)
    {
        return await Table<Testimonial>()
            .Where(x => x.Id == id)
            .Select(x => new TestimonialVm
            {
                Id = x.Id,
                FullName = x.FullName,
                JobTitle = x.jobTitle,
                Comment = x.Comment,
                Image = x.Image,
                Rate = x.Rate,
                SortOrder = x.OrderSort,
                IsActive = x.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Testimonial?> GetEntityByIdAsync(long id)
    {
        return await Table<Testimonial>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TestimonialVm>> GetActiveAsync()
    {
        return await Table<Testimonial>()
            .Where(x => x.IsActive)
            .OrderBy(x => x.OrderSort)
            .Select(x => new TestimonialVm
            {
                Id = x.Id,
                FullName = x.FullName,
                JobTitle = x.jobTitle,
                Comment = x.Comment,
                Image = x.Image,
                Rate = x.Rate,
                SortOrder = x.OrderSort,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<bool> CreateAsync(CreateTestimonialVm model)
    {
        var entity = new Testimonial
        {
            FullName = model.FullName,
            jobTitle = model.JobTitle,
            Comment = model.Comment,
            Rate = model.Rate,
            OrderSort = model.SortOrder,
            IsActive = model.IsActive
        };

        if (model.ImageFile != null)
        {
            entity.Image = await _imageService.UploadAsync(
                model.ImageFile,
                "testimonials",
                400,
                400);
        }

        CreateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(UpdateTestimonialVm model)
    {
        var entity = await Table<Testimonial>().FindAsync(model.Id);

        if (entity == null)
            return false;

        entity.FullName = model.FullName;
        entity.jobTitle = model.JobTitle;
        entity.Comment = model.Comment;
        entity.Rate = model.Rate;
        entity.OrderSort = model.SortOrder;
        entity.IsActive = model.IsActive;

        entity.Image = await _imageService.ReplaceAsync(
            model.ImageFile,
            entity.Image,
            "testimonials",
            400,
            400);

       UpdateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await Table<Testimonial>().FindAsync(id);

        if (entity == null)
            return false;

        await _imageService.DeleteAsync(
            entity.Image,
            "testimonials");

        DeleteAsync(id);

        return await SaveChangesAsync();
    }
}