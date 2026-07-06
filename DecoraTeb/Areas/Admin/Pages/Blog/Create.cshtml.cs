using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DecoraTeb.Areas.Admin.Pages.Blog;

public class CreateModel : PageModel
{
    private readonly IBlogService _blogService;
    private readonly IBlogCategoryService _categoryService;

    public CreateModel(
        IBlogService blogService,
        IBlogCategoryService categoryService)
    {
        _blogService = blogService;
        _categoryService = categoryService;
    }

    [BindProperty]
    public CreateBlogVm Blog { get; set; } = new();

    public List<SelectListItem> Categories { get; set; } = [];

    public async Task OnGetAsync()
    {
        Categories = await _categoryService.GetSelectListAsync();
        ViewData["Categories"] = Categories;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _categoryService.GetSelectListAsync();
            return Page();
        }

        var result = await _blogService.CreateAsync(Blog);

        if (!result)
        {
            ModelState.AddModelError("", "خطا در ثبت اطلاعات");
            Categories = await _categoryService.GetSelectListAsync();
            return Page();
        }

        return RedirectToPage("Index");
    }
}
