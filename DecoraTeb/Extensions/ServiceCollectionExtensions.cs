using DecoraTeb.Services;
using DecoraTeb.Services.Core;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.Services.Interfaces.Infrastructure;

namespace DecoraTeb.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IProjectCategoryService, ProjectCategoryService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IBlogCategoryService, BlogCategoryService>();
        services.AddScoped<IFaqService, FaqService>();
        //services.AddScoped<IPageService, PageService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<ITestimonialService, TestimonialService>();
        services.AddScoped<IContantRequestService, ContantRequestService>();
        services.AddScoped<IConsultationRequestService, ConsultationRequestService>();
        services.AddScoped<ISiteSettingService, SiteSettingService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IContactUsService, ContactUsService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ISlugService, SlugService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IWebPageService, WebPageService>();
        services.AddScoped<IProjectImageService, ProjectImageService>();
        return services;
    }
}
