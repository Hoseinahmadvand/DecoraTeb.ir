using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Project;

public class CreateModel : PageModel
{
    private readonly IProjectService _projectService;
    private readonly IProjectCategoryService _categoryService;

    public CreateModel(
        IProjectService projectService,
        IProjectCategoryService categoryService)
    {
        _projectService = projectService;
        _categoryService = categoryService;
    }

    [BindProperty]
    public CreateProjectVm Project { get; set; } = new();

    public async Task OnGetAsync()
    {
        ViewData["Categories"] = await _categoryService.GetSelectListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ViewData["Categories"] = await _categoryService.GetSelectListAsync();

        if (!ModelState.IsValid)
            return Page();

        var result = await _projectService.CreateAsync(Project);

        if (!result)
        {
            ModelState.AddModelError("", "خطا در ثبت پروژه");
            return Page();
        }

        return RedirectToPage("Index");
    }
}
