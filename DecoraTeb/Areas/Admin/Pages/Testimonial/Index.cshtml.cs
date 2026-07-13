using DecoraTeb.Services.Core;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Testimonial;

public class IndexModel : PageModel
{
    private readonly ITestimonialService _testimonialService;

    public IndexModel(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    public List<TestimonialVm> Testimonials { get; set; }
    public async void OnGet()
    {
        Testimonials=await _testimonialService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostToggleAsync(long id)
    {
        var entity = await _testimonialService.GetEntityByIdAsync(id);

        if (entity != null)
        {
            entity.IsActive = !entity.IsActive;

            await _testimonialService.UpdateAsync(entity);
        }

        return RedirectToPage();
    }
}
