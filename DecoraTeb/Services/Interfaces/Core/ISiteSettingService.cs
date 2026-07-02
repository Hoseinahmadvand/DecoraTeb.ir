using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using Microsoft.EntityFrameworkCore;
namespace DecoraTeb.Services.Interfaces.Core;

public interface ISiteSettingService
{
    Task<SiteSetting?> GetAsync();

    Task<bool> UpdateAsync(SiteSetting siteSetting);
}


public class SiteSettingService : BaseService, ISiteSettingService
{
    public SiteSettingService(
        ApplicationDbContext context,
        IWebHostEnvironment environment)
        : base(context, environment)
    {
    }

    public async Task<SiteSetting?> GetAsync()
    {
        return await _context.SiteSettings
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(SiteSetting siteSetting)
    {
        _context.SiteSettings.Update(siteSetting);

        return await _context.SaveChangesAsync() > 0;
    }
}
