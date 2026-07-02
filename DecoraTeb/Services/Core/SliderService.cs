using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class SliderService : CrudService<Slider>, ISliderService
{
    public SliderService(ApplicationDbContext context, IWebHostEnvironment environment, ILogger logger) : base(context, environment, logger)
    {
    }

    public async Task<List<Slider>> GetActiveSliderAsync()
    {
        var sliders = _context.Sliders.Where(s => s.IsActive == true).ToListAsync();
        return await sliders;
    }
}


