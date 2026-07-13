using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Pages;

public class ProjectsModel : PageModel
{
    private readonly IProjectService _projectService;

    public HomeProjectVm Projects { get; set; } = new();

    public ProjectsModel(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task OnGet()
    {
        Projects = await _projectService.GetHomeProjectsAsync();
    }
}
