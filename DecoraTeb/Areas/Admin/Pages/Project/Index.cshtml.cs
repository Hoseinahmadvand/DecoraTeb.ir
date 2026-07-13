using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Project;

public class IndexModel : PageModel
{
    private readonly IProjectService _projectService;

    public IndexModel(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [BindProperty(SupportsGet = true)]
    public FilterProjectVm Filter { get; set; } = new();
    public List<ProjectVm> Project { get; set; } = new();

    public async Task OnGetAsync()
    {
       // Filter = await _projectService.FilterAsync(Filter);
        Project = await _projectService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(long id)
    {
        await _projectService.DeleteAsync(id);

        return RedirectToPage();
    }
}
