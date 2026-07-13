using DecoraTeb.ViewModels.Blog;
using DecoraTeb.ViewModels.Faq;
using DecoraTeb.ViewModels.Project;
using DecoraTeb.ViewModels.ProjectCategory;
using DecoraTeb.ViewModels.Service;
using DecoraTeb.ViewModels.SiteSetting;
using DecoraTeb.ViewModels.Slider;
using DecoraTeb.ViewModels.Testimonial;
namespace DecoraTeb.ViewModels;



public class HomeVm
{
    public List<SliderVm> Sliders { get; set; } = [];

    public List<ServiceVm> Services { get; set; } = [];

    public HomeProjectVm Projects { get; set; } = new();

    public List<TestimonialVm> Testimonials { get; set; } = [];
    public List<BlogListItemVm> LatestBlogs { get; set; } = [];

    public List<FaqVm> Faqs { get; set; } = [];
}

public class HomeProjectVm
{
    public List<ProjectCategoryVm> Categories { get; set; }

    public List<ProjectVm> Projects { get; set; }
}
