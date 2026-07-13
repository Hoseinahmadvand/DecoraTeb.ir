using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Blog;
using DecoraTeb.ViewModels.BlogCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Pages;

public class BlogsModel : PageModel
{
    private readonly IBlogCategoryService _blogCategoryService;
    private readonly IBlogService _blogService;

    public BlogsModel(IBlogCategoryService blogCategoryService, IBlogService blogService)
    {
        _blogCategoryService = blogCategoryService;
        _blogService = blogService;
    }
    public List<BlogCategoryListItemVm> CategoryListItem { get; set; }
    public List<BlogListItemVm> BlogListItem { get; set; }
    public async Task<IActionResult> OnGet()
    {
        CategoryListItem=await _blogCategoryService.GetAllAsync();
        BlogListItem=await _blogService.GetAllAsync();
        return Page();
    }
}
