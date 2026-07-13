using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.Services.Interfaces.Infrastructure;
using DecoraTeb.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class SliderService : CrudService<Slider>, ISliderService
{

    private readonly IImageService _imageService;
    public SliderService(
        ApplicationDbContext context,
        IWebHostEnvironment environment
,
        IImageService imageService) : base(context, environment)
    {
        _imageService = imageService;
    }


    public async Task<bool> CreateAsync(CreateSliderVm model)
    {
        var slider = new Slider
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Description = model.Description,

            Image = model.Image,
        

            ButtonText = model.ButtonText,
            ButtonLink = model.ButtonLink,

            SortOrder = model.SortOrder,
            IsActive = model.IsActive,


            Slug = model.Slug,
            SeoTitle = model.SeoTitle,
            SeoDescription = model.SeoDescription,
            SeoKeywords = model.SeoKeywords,
            CanonicalUrl = model.CanonicalUrl,
            Robots = model.Robots
        };

      

        if (model.ImageFile != null)
        {
            slider.Image = await _imageService.UploadAsync(model.ImageFile, "slider", 600, 400);
        }
        return await CreateEntityAsync(slider);
    }


    public async Task<bool> UpdateAsync(UpdateSliderVm model)
    {
        var slider = await GetByIdAsync(model.Id);

        if (slider == null)
            return false;


        slider.Title = model.Title;
        slider.SubTitle = model.SubTitle;
        slider.Description = model.Description;

        slider.Image = model.Image;
      

        slider.ButtonText = model.ButtonText;
        slider.ButtonLink = model.ButtonLink;

        slider.SortOrder = model.SortOrder;
        slider.IsActive = model.IsActive;


        slider.Slug = model.Slug;
        slider.SeoTitle = model.SeoTitle;
        slider.SeoDescription = model.SeoDescription;
        slider.SeoKeywords = model.SeoKeywords;
        slider.CanonicalUrl = model.CanonicalUrl;
        slider.Robots = model.Robots;


        return true;
    }



    public async Task<SliderVm?> GetByIdAsync(long id)
    {
        var slider = await base.GetByIdAsync(id);

        if (slider == null)
            return null;


        return new SliderVm
        {
            Id = slider.Id,

            Title = slider.Title,
            SubTitle = slider.SubTitle,
            Description = slider.Description,

            Image = slider.Image,
      

            ButtonText = slider.ButtonText,
            ButtonLink = slider.ButtonLink,

            SortOrder = slider.SortOrder,
            IsActive = slider.IsActive,


            Slug = slider.Slug,
            SeoTitle = slider.SeoTitle,
            SeoDescription = slider.SeoDescription,
            SeoKeywords = slider.SeoKeywords,
            CanonicalUrl = slider.CanonicalUrl,
            Robots = slider.Robots
        };
    }



    public async Task<List<SliderListVm>> GetAllAsync()
    {
        return await Table<Slider>()
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.SortOrder)
            .Select(x => new SliderListVm
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive,
                CreateAt = x.CreateAt
            })
            .AsNoTracking()
            .ToListAsync();
    }



    public async Task<List<SliderVm>> GetActiveSliderAsync()
    {
        return await Table<Slider>()
            .Where(x => x.IsActive && !x.IsDeleted)
            .OrderBy(x => x.SortOrder)
            .Select(x => new SliderVm
            {
                Id = x.Id,

                Title = x.Title,
                SubTitle = x.SubTitle,
                Description = x.Description,

                Image = x.Image,
            

                ButtonText = x.ButtonText,
                ButtonLink = x.ButtonLink,

                SortOrder = x.SortOrder,
                IsActive = x.IsActive,

                Slug = x.Slug,
                SeoTitle = x.SeoTitle,
                SeoDescription = x.SeoDescription,
                SeoKeywords = x.SeoKeywords,
                CanonicalUrl = x.CanonicalUrl,
                Robots = x.Robots

            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<SliderVm>> GetActiveAsync()
    {
        var model = await Table<Slider>()
    .Where(x => !x.IsDeleted && x.IsActive)
    .OrderBy(x => x.SortOrder)
    .Select(x => new SliderVm
    {
        Id = x.Id,
        Title = x.Title,
        Image = x.Image,
        SortOrder = x.SortOrder,
        IsActive = x.IsActive

    })
    .AsNoTracking()
    .ToListAsync();

        return model;
    }
}



