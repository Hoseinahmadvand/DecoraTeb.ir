using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Blog;

public class IndexModel : PageModel
{
    private readonly IBlogService _blogService;

    public IndexModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public List<BlogListItemVm> Blogs { get; set; } = [];

    public async Task OnGetAsync()
    {
        Blogs = await _blogService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(long id)
    {
        await _blogService.DeleteAsync(id);

        return RedirectToPage();
    }
}
