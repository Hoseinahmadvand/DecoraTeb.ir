using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.Project;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IProjectImageService
{
    Task<List<ProjectImageListVm>> GetByProjectId(long projectId);

    Task<ProjectImageVm?> GetById(long id);

    Task<bool> Create(ProjectImageVm vm);

    Task<bool> Update(ProjectImageVm vm);

    Task<bool> Delete(long id);

    Task<bool> ChangeCover(long id);

    Task<bool> ChangeStatus(long id);
}

public class ProjectImageService : IProjectImageService
{
    private readonly ApplicationDbContext _context;

    public ProjectImageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectImageListVm>> GetByProjectId(long projectId)
    {
        return await _context.ProjectImages
            .Where(x => x.ProjectId == projectId)
            .OrderByDescending(x => x.IsCover)
            .ThenBy(x => x.SortOrder)
            .Select(x => new ProjectImageListVm
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                Image = x.Image,
                Name = x.Name,
                Alt = x.Alt,
                IsCover = x.IsCover,
                SortOrder = x.SortOrder,
                IsActive = x.IsActive
            }).ToListAsync();
    }

    public async Task<ProjectImageVm?> GetById(long id)
    {
        return await _context.ProjectImages
            .Where(x => x.Id == id)
            .Select(x => new ProjectImageVm
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                Name = x.Name,
                Alt = x.Alt,
                Image = x.Image,
                IsCover = x.IsCover,
                SortOrder = x.SortOrder
            }).FirstOrDefaultAsync();
    }

    public async Task<bool> Create(ProjectImageVm vm)
    {
        var entity = new ProjectImage
        {
            ProjectId = vm.ProjectId,
            Name = vm.Name,
            Alt = vm.Alt,
            Image = vm.Image!,
            SortOrder = vm.SortOrder,
            IsCover = vm.IsCover,
            IsActive = true
        };

        if (vm.IsCover)
        {
            var covers = await _context.ProjectImages
                .Where(x => x.ProjectId == vm.ProjectId)
                .ToListAsync();

            foreach (var item in covers)
                item.IsCover = false;
        }

        await _context.ProjectImages.AddAsync(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(ProjectImageVm vm)
    {
        var entity = await _context.ProjectImages.FindAsync(vm.Id);

        if (entity == null)
            return false;

        entity.Name = vm.Name;
        entity.Alt = vm.Alt;
        entity.SortOrder = vm.SortOrder;

        if (!string.IsNullOrEmpty(vm.Image))
            entity.Image = vm.Image;

        if (vm.IsCover)
        {
            var covers = await _context.ProjectImages
                .Where(x => x.ProjectId == entity.ProjectId)
                .ToListAsync();

            foreach (var item in covers)
                item.IsCover = false;

            entity.IsCover = true;
        }

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(long id)
    {
        var entity = await _context.ProjectImages.FindAsync(id);

        if (entity == null)
            return false;

        _context.ProjectImages.Remove(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ChangeCover(long id)
    {
        var image = await _context.ProjectImages.FindAsync(id);

        if (image == null)
            return false;

        var covers = await _context.ProjectImages
            .Where(x => x.ProjectId == image.ProjectId)
            .ToListAsync();

        foreach (var item in covers)
            item.IsCover = false;

        image.IsCover = true;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ChangeStatus(long id)
    {
        var entity = await _context.ProjectImages.FindAsync(id);

        if (entity == null)
            return false;

        entity.IsActive = !entity.IsActive;

        return await _context.SaveChangesAsync() > 0;
    }
}