using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.Services.Interfaces.Infrastructure;
using DecoraTeb.ViewModels;
using DecoraTeb.ViewModels.Project;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class ProjectService
    : CrudService<Project>, IProjectService
{
    private readonly IImageService _imageService;
    private readonly IProjectCategoryService _categoryService;
    public ProjectService(
        ApplicationDbContext context,
        IWebHostEnvironment environment
,
        IImageService imageService,
        IProjectCategoryService categoryService)
        : base(context, environment)
    {
        _imageService = imageService;
        _categoryService = categoryService;
    }

    public async Task<bool> CreateAsync(CreateProjectVm model)
    {
        var entity = new Project
        {
            Title = model.Title,
            Summary = model.Summary,
            Description = model.Description,
            Location = model.Location,
            Area = model.Area,
            ExecutionYear = model.ExecutionYear,
            ClientName = model.ClientName,
            ProjectCategoryId = model.ProjectCategoryId,
            IsFeatured = model.IsFeatured,
            SortOrder = model.SortOrder,

            Slug = model.Slug,
            SeoTitle = model.SeoTitle,
            SeoDescription = model.SeoDescription,
            SeoKeywords = model.SeoKeywords,
            CanonicalUrl = model.CanonicalUrl,
            Robots = model.Robots
        };



        if (model.CoverImage != null)
        {
            entity.CoverImage = await _imageService.UploadAsync(
                model.CoverImage,
                "projects",
                1400,
                900);
        }

        await CreateEntityAsync(entity);
        await SaveChangesAsync();
        if (model.GalleryImages != null)
        {
            foreach (var file in model.GalleryImages)
            {
                var imageName = await _imageService.UploadAsync(file, $"project/{model.Title}");

                _context.ProjectImages.Add(new ProjectImage
                {
                    ProjectId = entity.Id,
                    Image = imageName,
                    Name = model.Title,
                    Alt = model.Title
                });
            }

            await SaveChangesAsync();
        }
        return true;
    }

    public Task<FilterProjectVm> FilterAsync(FilterProjectVm filter)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProjectVm>> GetByCategoryAsync(long categoryId)
    {
        return await Table<Project>()
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => x.ProjectCategoryId == categoryId)
            .OrderByDescending(x => x.CreateAt)
            .Select(x => new ProjectVm
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,

                CoverImage = x.CoverImage,
                ProjectCategoryId = x.ProjectCategoryId,
                CategoryTitle = x.Category!.Title,
                IsFeatured = x.IsFeatured,
                Slug = x.Slug
            })
            .ToListAsync();
    }

    public async Task<ProjectVm?> GetBySlugAsync(string slug)
    {
        var project = await Table<Project>()
            .Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == slug);

        if (project == null)
            return null;

        return new ProjectVm
        {
            Id = project.Id,
            Title = project.Title,
            Summary = project.Summary,
            Description = project.Description,

            CoverImage = project.CoverImage,
            Location = project.Location,
            Area = project.Area,
            ExecutionYear = project.ExecutionYear,
            ClientName = project.ClientName,
            IsFeatured = project.IsFeatured,
            SortOrder = project.SortOrder,
            ProjectCategoryId = project.ProjectCategoryId,
            CategoryTitle = project.Category?.Title,
            Slug = project.Slug,
            SeoTitle = project.SeoTitle,
            SeoDescription = project.SeoDescription,
            SeoKeywords = project.SeoKeywords,
            CanonicalUrl = project.CanonicalUrl,
            Robots = project.Robots
        };
    }

    public async Task<Project?> GetEntityByIdAsync(long id)
    {
        return await Table<Project>()
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ProjectVm>> GetFeaturedProjectsAsync(int take = 6)
    {
        return await Table<Project>()
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => x.IsFeatured)
            .OrderBy(x => x.SortOrder)
            .Take(take)
            .Select(x => new ProjectVm
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,

                CoverImage = x.CoverImage,
                Slug = x.Slug,
                ProjectCategoryId = x.ProjectCategoryId,
                CategoryTitle = x.Category!.Title,
                IsFeatured = x.IsFeatured,
                SortOrder = x.SortOrder
            })
            .ToListAsync();
    }

    public async Task<List<ProjectVm>> GetLastProjectsAsync(int take = 6)
    {
        return await Table<Project>()
            .AsNoTracking()
            .Include(x => x.Category)
            .OrderByDescending(x => x.CreateAt)
            .Take(take)
            .Select(x => new ProjectVm
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,

                CoverImage = x.CoverImage,
                Slug = x.Slug,
                ProjectCategoryId = x.ProjectCategoryId,
                CategoryTitle = x.Category!.Title,
                IsFeatured = x.IsFeatured,
                SortOrder = x.SortOrder
            })
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(UpdateProjectVm model)
    {
        var entity = await GetEntityByIdAsync(model.Id);

        if (entity == null)
            return false;

        entity.Title = model.Title;
        entity.Summary = model.Summary;
        entity.Description = model.Description;

        entity.Location = model.Location;
        entity.Area = model.Area;
        entity.ExecutionYear = model.ExecutionYear;
        entity.ClientName = model.ClientName;

        entity.ProjectCategoryId = model.ProjectCategoryId;

        entity.IsFeatured = model.IsFeatured;
        entity.SortOrder = model.SortOrder;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;
        entity.Robots = model.Robots;



        entity.CoverImage = await _imageService.ReplaceAsync(
            model.CoverImage,
            entity.CoverImage,
            "projects",
            1400,
            900);

        UpdateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<List<ProjectVm>> GetAllAsync()
    {
        return await Table<Project>()
            .AsNoTracking()
            .Include(x => x.Category)
            .OrderByDescending(x => x.CreateAt)
            .Select(x => new ProjectVm
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                Description = x.Description,


                CoverImage = x.CoverImage,

                Location = x.Location,
                Area = x.Area,
                ExecutionYear = x.ExecutionYear,
                ClientName = x.ClientName,

                ProjectCategoryId = x.ProjectCategoryId,
                CategoryTitle = x.Category!.Title,

                IsFeatured = x.IsFeatured,
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

    public async Task<ProjectVm?> GetByIdAsync(long id)
    {
        return await Table<Project>()
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => x.Id == id)
            .Select(x => new ProjectVm
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                Description = x.Description,


                CoverImage = x.CoverImage,

                Location = x.Location,
                Area = x.Area,
                ExecutionYear = x.ExecutionYear,
                ClientName = x.ClientName,

                ProjectCategoryId = x.ProjectCategoryId,
                CategoryTitle = x.Category!.Title,

                IsFeatured = x.IsFeatured,
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
    private static ProjectVm ToVm(Project entity)
    {
        return new ProjectVm
        {
            Id = entity.Id,
            Title = entity.Title,
            Summary = entity.Summary,

            CoverImage = entity.CoverImage,
            CategoryTitle = entity.Category?.Title ?? "",
            IsFeatured = entity.IsFeatured,
            SortOrder = entity.SortOrder
        };
    }
    private static void Map(CreateProjectVm model, Project entity)
    {
        entity.Title = model.Title;
        entity.Summary = model.Summary;
        entity.Description = model.Description;

        entity.Location = model.Location;
        entity.Area = model.Area;
        entity.ExecutionYear = model.ExecutionYear;
        entity.ClientName = model.ClientName;

        entity.ProjectCategoryId = model.ProjectCategoryId;

        entity.IsFeatured = model.IsFeatured;
        entity.SortOrder = model.SortOrder;

        entity.Slug = model.Slug;
        entity.SeoTitle = model.SeoTitle;
        entity.SeoDescription = model.SeoDescription;
        entity.SeoKeywords = model.SeoKeywords;
        entity.CanonicalUrl = model.CanonicalUrl;
        entity.Robots = model.Robots;
    }

    public async Task<HomeProjectVm> GetHomeProjectsAsync()
    {
        var model = new HomeProjectVm
        {
            Categories = await _categoryService.GetAllAsync(),

            Projects = await _context.Projects
                       .OrderByDescending(x => x.CreateAt)
                       .Take(9)
                       .Select(x => new ProjectVm
                       {
                           Id = x.Id,
                           Title = x.Title,
                           Slug = x.Slug,
                           CoverImage = x.CoverImage,
                           Area = x.Area,
                           Location = x.Location,
                           //Category = x.Category.Slug,
                           CategoryTitle = x.Category.Title,
                           Summary = x.Summary
                       })
                       .ToListAsync()
        };
        return model;
    }

    public async Task<ProjectDetailVm?> GetDetailAsync(string slug)
    {
        var project = await Table<Project>()
            .Include(x => x.Category)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Slug == slug);

        if (project == null)
            return null;

        var related = await Table<Project>()
            .Include(x => x.Category)
            .Where(x => x.ProjectCategoryId == project.ProjectCategoryId &&
                        x.Id != project.Id)
            .Take(3)
            .ToListAsync();

        var projectDetail = new ProjectDetailVm
        {
            Id = project.Id,
            Title = project.Title,
            Summary = project.Summary,
            Description = project.Description,
            CoverImage = project.CoverImage,
            Category = project.Category.Title,
            Location = project.Location,
            Area = project.Area,
            ExecutionYear = project.ExecutionYear,
            ClientName = project.ClientName,

            Gallery = project.Images
                .Select(x => new ProjectImageVm
                {
                    Id = x.Id,
                    Image = x.Image,
                    Alt = x.Alt
                })
                .ToList(),

            RelatedProjects = related
                .Select(x => new ProjectCardVm
                {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    CoverImage = x.CoverImage,
                    Summary = x.Summary,
                    CategoryName = x.Category.Title,
                    Location = x.Location,
                    Area = x.Area,
                    ExecutionYear = x.ExecutionYear,
                    IsFeatured = x.IsFeatured
                })
                .ToList()
        };
        var count = project.Images.Count;
        return projectDetail;
    }

}




