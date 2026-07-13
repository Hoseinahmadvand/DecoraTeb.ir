using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Slider;

public class CreateModel : PageModel
{
    private readonly ISliderService _sliderService;

    public CreateModel(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [BindProperty]
    public CreateSliderVm Slider { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _sliderService.CreateAsync(Slider);

        if (!result)
        {
            ModelState.AddModelError("", "خطا در ثبت اسلایدر");
            return Page();
        }

        return RedirectToPage("Index");
    }
}
