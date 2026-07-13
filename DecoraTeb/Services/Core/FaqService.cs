using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Faq;
using Microsoft.EntityFrameworkCore;
namespace DecoraTeb.Services.Core;
public class FaqService
    : CrudService<FAQ>, IFaqService
{
 

    public FaqService(
        ApplicationDbContext context,
        IWebHostEnvironment environment)
        : base(context, environment)
    {
    
    }

    public async Task<List<FaqVm>> GetAllAsync()
    {
        return await Table<FAQ>()
            .OrderBy(x => x.OrderSort)
            .Select(x => new FaqVm
            {
                Id = x.Id,
                Question = x.Question,
                Answer = x.Answer,
                OrderSort = x.OrderSort,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<FaqVm?> GetByIdAsync(long id)
    {
        return await Table<FAQ>()
            .Where(x => x.Id == id)
            .Select(x => new FaqVm
            {
                Id = x.Id,
                Question = x.Question,
                Answer = x.Answer,
                OrderSort = x.OrderSort,
                IsActive = x.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task<FAQ?> GetEntityByIdAsync(long id)
    {
        return await Table<FAQ>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<FaqVm>> GetActiveAsync()
    {
        return await Table<FAQ>()
            .Where(x => x.IsActive)
            .OrderBy(x => x.OrderSort)
            .Select(x => new FaqVm
            {
                Id = x.Id,
                Question = x.Question,
                Answer = x.Answer,
                OrderSort = x.OrderSort,
                IsActive = x.IsActive
            })
            .ToListAsync();
    }

    public async Task<bool> CreateAsync(CreateFaqVm model)
    {
        var entity = new FAQ
        {
            Question = model.Question,
            Answer = model.Answer,
            OrderSort = model.OrderSort,
            IsActive = model.IsActive
        };

        await CreateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(UpdateFaqVm model)
    {
        var entity = await Table<FAQ>().FindAsync(model.Id);

        if (entity == null)
            return false;

        entity.Question = model.Question;
        entity.Answer = model.Answer;
        entity.OrderSort = model.OrderSort;
        entity.IsActive = model.IsActive;

      await  UpdateEntityAsync(entity);

        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await Table<FAQ>().FindAsync(id);

        if (entity == null)
            return false;

      await DeleteAsync(id);

        return await SaveChangesAsync();
    }
}