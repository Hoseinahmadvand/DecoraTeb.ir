using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Slider;

public class IndexModel : PageModel
{
    private readonly ISliderService _sliderService;

    public IndexModel(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public List<SliderListVm> Sliders { get; set; } = [];

    public async Task OnGetAsync()
    {
        Sliders = await _sliderService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(long id)
    {
        await _sliderService.DeleteAsync(id);

        return RedirectToPage();
    }
}
