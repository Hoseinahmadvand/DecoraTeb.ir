using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Slider;

public class EditModel : PageModel
{
    private readonly ISliderService _sliderService;

    public EditModel(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [BindProperty]
    public UpdateSliderVm Slider { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(long id)
    {
        var slider = await _sliderService.GetByIdAsync(id);

        if (slider == null)
            return NotFound();

        Slider = new UpdateSliderVm
        {
            Id = slider.Id,

            Title = slider.Title,
            SubTitle = slider.SubTitle,
            Description = slider.Description,

            Image = slider.Image,
          

            ButtonText = slider.ButtonText,
            ButtonLink = slider.ButtonLink,

            SortOrder = slider.SortOrder,
            IsActive = slider.IsActive,

            Slug = slider.Slug,
            SeoTitle = slider.SeoTitle,
            SeoDescription = slider.SeoDescription,
            SeoKeywords = slider.SeoKeywords,
            CanonicalUrl = slider.CanonicalUrl,
            Robots = slider.Robots
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _sliderService.UpdateAsync(Slider);

        if (!result)
        {
            ModelState.AddModelError("", "ویرایش انجام نشد");
            return Page();
        }

        return RedirectToPage("Index");
    }
}