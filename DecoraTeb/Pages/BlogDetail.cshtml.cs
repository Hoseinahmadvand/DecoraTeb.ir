using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Pages;

public class BlogDetailModel : PageModel
{
    private readonly IBlogService _blogService;

    public BlogDetailModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public BlogDetailVm Blog { get; set; } = new();

    public async Task<IActionResult> OnGet(string slug)
    {
        Blog = await _blogService.GetDetailAsync(slug);

        if (Blog == null)
            return NotFound();

        return Page();
    }
}
