using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;

namespace DecoraTeb.Services.Core;

public class FaqService : CrudService<FAQ>, IFaqService
{
    public FaqService(ApplicationDbContext context, IWebHostEnvironment environment, ILogger logger) : base(context, environment, logger)
    {
    }
}


