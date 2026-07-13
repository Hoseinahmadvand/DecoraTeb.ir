using DecoraTeb.Data.Context;
using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Base;
using DecoraTeb.Services.Interfaces.Core;

namespace DecoraTeb.Services.Core;

public class PageService : CrudService<WebPage>
{
    public PageService(ApplicationDbContext context, IWebHostEnvironment environment) : base(context, environment)
    {
    }
}


