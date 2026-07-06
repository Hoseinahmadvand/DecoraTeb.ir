using DecoraTeb.ViewModels.Blog;
using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.BlogCategory;



public class BlogCategoryVm : SeoVm
{
    public long Id { get; set; }

    [Required]
    public string Title { get; set; }

   
}public class CreateOrUpdateBlogCategoryVm : SeoVm
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public string? Description { get; set; }


}
public class BlogCategoryListItemVm : SeoVm
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Slug { get; set; }


}


