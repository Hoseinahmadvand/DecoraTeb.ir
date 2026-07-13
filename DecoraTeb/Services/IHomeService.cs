using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels;



namespace DecoraTeb.Services;

public interface IHomeService
{
    Task<HomeVm> GetHomePageAsync();
}

public class HomeService : IHomeService
{
    private readonly ISliderService _sliderService;
    private readonly IServiceService _serviceService;
    private readonly IProjectService _projectService;
    private readonly ITestimonialService _testimonialService;
    private readonly IBlogService _blogService;
    private readonly IFaqService _faqService;
    private readonly ISiteSettingService _siteSettingService;

    public HomeService(
        ISliderService sliderService,
        IServiceService serviceService,
        IProjectService projectService,
        ITestimonialService testimonialService,
        IBlogService blogService,
        IFaqService faqService,
        ISiteSettingService siteSettingService)
    {
        _sliderService = sliderService;
        _serviceService = serviceService;
        _projectService = projectService;
        _testimonialService = testimonialService;
        _blogService = blogService;
        _faqService = faqService;
        _siteSettingService = siteSettingService;
    }

    public async Task<HomeVm> GetHomePageAsync()
    {
        var model = new HomeVm
        {
            Sliders = await _sliderService.GetActiveAsync(),

            Services = await _serviceService.GetActiveAsync(),

            Projects = await _projectService.GetHomeProjectsAsync(),

            Testimonials = await _testimonialService.GetActiveAsync(),

            LatestBlogs = await _blogService.GetLastBlogsAsync(3),

            Faqs = await _faqService.GetActiveAsync(),

        //    SiteSetting = await _siteSettingService.GetAsync()
        };

        return model;
    }
}
