using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.WebPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.WebPage;


public class EditModel : PageModel
{
    private readonly IWebPageService _service;

    public EditModel(IWebPageService service)
    {
        _service = service;
    }

    [BindProperty]
    public WebPageVm PageVm { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        PageVm = result;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _service.UpdateAsync(PageVm);

        return RedirectToPage("Index");
    }
}

