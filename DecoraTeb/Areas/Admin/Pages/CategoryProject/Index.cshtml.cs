using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.ProjectCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.CategoryProject;

public class IndexModel : PageModel
{
    private readonly IProjectCategoryService _service;

    public IndexModel(IProjectCategoryService service)
    {
        _service = service;
    }

    public List<ProjectCategoryVm> Categories { get; set; } = [];

    [BindProperty]
    public CreateProjectCategoryVm CreateModel { get; set; } = new();

    [BindProperty]
    public UpdateProjectCategoryVm UpdateModel { get; set; } = new();

    public async Task OnGetAsync()
    {
        Categories = await _service.GetAllAsync();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _service.GetAllAsync();
            return Page();
        }

        await _service.CreateAsync(CreateModel);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEditAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _service.GetAllAsync();
            return Page();
        }

        await _service.UpdateAsync(UpdateModel);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(long id)
    {
        await _service.DeleteAsync(id);

        return RedirectToPage();
    }
}
