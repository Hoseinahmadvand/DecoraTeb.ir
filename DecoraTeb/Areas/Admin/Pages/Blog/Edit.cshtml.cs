using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DecoraTeb.Areas.Admin.Pages.Blog;

public class EditModel : PageModel
{
    private readonly IBlogService _blogService;
    private readonly IBlogCategoryService _categoryService;

    public EditModel(
        IBlogService blogService,
        IBlogCategoryService categoryService)
    {
        _blogService = blogService;
        _categoryService = categoryService;
    }

    [BindProperty]
    public UpdateBlogVm Blog { get; set; } = new();

    public List<SelectListItem> Categories { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(long id)
    {
        var model = await _blogService.GetForEditAsync(id);

        if (model == null)
            return NotFound();

        Blog = model;

        Categories = await _categoryService.GetSelectListAsync();
        ViewData["Categories"] = Categories;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _categoryService.GetSelectListAsync();
            return Page();
        }

        var result = await _blogService.UpdateAsync(Blog);

        if (!result)
        {
            ModelState.AddModelError("", "خطا در ویرایش اطلاعات");
            Categories = await _categoryService.GetSelectListAsync();
            return Page();
        }

        return RedirectToPage("Index");
    }
}
