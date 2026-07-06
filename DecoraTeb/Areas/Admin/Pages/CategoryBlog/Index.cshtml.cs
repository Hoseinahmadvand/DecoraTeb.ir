using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.BlogCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.CategoryBlog;

public class IndexModel : PageModel
{
    private readonly IBlogCategoryService _service;

    public IndexModel(IBlogCategoryService service)
    {
        _service = service;
    }

    public List<BlogCategoryListItemVm> Categories { get; set; } = [];

    [BindProperty]
    public CreateOrUpdateBlogCategoryVm Category { get; set; } = new();

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

        await _service.CreateAsync(Category);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEditAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _service.GetAllAsync();
            return Page();
        }

        await _service.UpdateAsync(Category);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(long id)
    {
        await _service.DeleteAsync(id);

        return RedirectToPage();
    }
}
