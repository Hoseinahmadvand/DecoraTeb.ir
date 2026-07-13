using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Services;

public class CreateModel : PageModel
{
    private readonly IServiceService _service;

    public CreateModel(IServiceService service)
    {
        _service = service;
    }

    public void OnGet()
    {
    }

    [BindProperty]
    public CreateServiceVm createService { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (ModelState.IsValid)
            return Page();
        var result = await _service.CreateAsync(createService);
        if (!result)
        {
            ModelState.AddModelError("", "خطا در ثبت پروژه");
            return Page();
        }
        return RedirectToPage("Index");
    }


}
