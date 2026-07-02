using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace DecoraTeb.Services.Core;

public class ServiceService : CrudService<Service>, IServiceService
{
    public ServiceService(ApplicationDbContext context, IWebHostEnvironment environment, ILogger logger) : base(context, environment, logger)
    {
    }

    public async Task<List<Service>> GetActiveServicesAsync()
    {
        var services = _context.Services.Where(x => x.IsActive).ToListAsync();

        return await services;
    }
}


