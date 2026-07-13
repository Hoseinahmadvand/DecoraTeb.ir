using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Project;

public class EditModel : PageModel
{
    private readonly IProjectService _projectService;
    private readonly IProjectCategoryService _categoryService;

    public EditModel(
        IProjectService projectService,
        IProjectCategoryService categoryService)
    {
        _projectService = projectService;
        _categoryService = categoryService;
    }

    [BindProperty]
    public UpdateProjectVm Project { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(long id)
    {
        ViewData["Categories"] = await _categoryService.GetSelectListAsync();

        var project = await _projectService.GetByIdAsync(id);

        if (project == null)
            return NotFound();

        Project = new UpdateProjectVm
        {
            Id = project.Id,
            Title = project.Title,
            Summary = project.Summary,
            Description = project.Description,

            Location = project.Location,
            Area = project.Area,
            ExecutionYear = project.ExecutionYear,
            ClientName = project.ClientName,

            ProjectCategoryId = project.ProjectCategoryId,

            IsFeatured = project.IsFeatured,
            SortOrder = project.SortOrder,

            Slug = project.Slug,
            SeoTitle = project.SeoTitle,
            SeoDescription = project.SeoDescription,
            SeoKeywords = project.SeoKeywords,
            CanonicalUrl = project.CanonicalUrl,
            Robots = project.Robots,

          
            CurrentCoverImage = project.CoverImage
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ViewData["Categories"] = await _categoryService.GetSelectListAsync();

        if (!ModelState.IsValid)
            return Page();

        var result = await _projectService.UpdateAsync(Project);

        if (!result)
        {
            ModelState.AddModelError("", "ویرایش پروژه انجام نشد.");
            return Page();
        }

        return RedirectToPage("Index");
    }
}
