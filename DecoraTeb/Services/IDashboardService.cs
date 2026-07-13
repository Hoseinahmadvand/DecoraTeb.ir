using DecoraTeb.Data.Context;
using DecoraTeb.ViewModels;
using Microsoft.EntityFrameworkCore;



namespace DecoraTeb.Services;

public interface IDashboardService
{
    Task<DashboardVm> GetDashboardAsync();
}

public class DashboardService : IDashboardService
{
    private readonly ApplicationDbContext _context;

    public DashboardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardVm> GetDashboardAsync()
    {
        var vm = new DashboardVm
        {
            ProjectCount = await _context.Projects.CountAsync(),

            BlogCount = await _context.Blogs.CountAsync(),

            ServiceCount = await _context.Services.CountAsync(),

            SliderCount = await _context.Sliders.CountAsync(),

            FaqCount = await _context.FAQs.CountAsync(),

            TestimonialCount = await _context.Testimonials.CountAsync(),

            MessageCount = await _context.ContactUs.CountAsync(),

            LatestProjects = await _context.Projects
                .OrderByDescending(x => x.CreateAt)
                .Take(5)
                .Select(x => new DashboardProjectVm
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsActive = x.IsActive,
                    CreateDate = x.CreateAt
                })
                .ToListAsync(),

            LatestBlogs = await _context.Blogs
                .OrderByDescending(x => x.CreateAt)
                .Take(5)
                .Select(x => new DashboardBlogVm
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreateDate = x.CreateAt
                })
                .ToListAsync()
        };

        return vm;
    }
}