using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.ContactUs;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class ContactUsService : IContactUsService
{
    private readonly ApplicationDbContext _context;

    public ContactUsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContactUsListVm>> GetAllAsync()
    {
        return await _context.ContactUs
            .OrderByDescending(x => x.CreateAt)
            .Select(x => new ContactUsListVm
            {
                Id = x.Id,
                FullName = x.FullName,
                PhoneNumber = x.PhoneNumber,
                Subject = x.Subject,
                IsRead = x.IsRead,
                IsAnswered = x.IsAnswered,
                CreateDate = x.CreateAt
            })
            .ToListAsync();
    }

    public async Task<ContactUsVm?> GetByIdAsync(int id)
    {
        return await _context.ContactUs
            .Where(x => x.Id == id)
            .Select(x => new ContactUsVm
            {
                Id = x.Id,
                FullName = x.FullName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
                IsRead = x.IsRead,
                IsAnswered = x.IsAnswered,
                CreateDate = x.CreateAt
            })
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(ContactUsVm model)
    {
        var entity = new ContactUs
        {
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            Subject = model.Subject,
            Message = model.Message,
            IsRead = false,
            IsAnswered = false
        };

        _context.ContactUs.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ChangeReadStatusAsync(int id)
    {
        var entity = await _context.ContactUs.FindAsync(id);

        if (entity == null)
            return false;

        entity.IsRead = !entity.IsRead;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ChangeAnsweredStatusAsync(int id)
    {
        var entity = await _context.ContactUs.FindAsync(id);

        if (entity == null)
            return false;

        entity.IsAnswered = !entity.IsAnswered;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.ContactUs.FindAsync(id);

        if (entity == null)
            return false;

        _context.ContactUs.Remove(entity);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<int> GetUnreadCountAsync()
    {
        return await _context.ContactUs
            .CountAsync(x => !x.IsRead);
    }
}