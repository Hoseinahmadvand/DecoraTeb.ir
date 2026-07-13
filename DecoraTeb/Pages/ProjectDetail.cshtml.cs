using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Pages
{
    public class ProjectDetailModel : PageModel
    {
        private readonly IProjectService _projectService;

        public ProjectDetailModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ProjectDetailVm Project { get; set; }

        public async Task<IActionResult> OnGet(string slug)
        {
            Project = await _projectService.GetDetailAsync(slug);

            if (Project == null)
                return NotFound();

            return Page();
        }
    }
}
