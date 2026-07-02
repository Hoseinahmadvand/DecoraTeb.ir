using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Blog;

public class BlogCreateVM
{
    [Required]
    [Display(Name = "عنوان")]
    [MaxLength(250)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Display(Name = "خلاصه")]
    public string Summary { get; set; } = string.Empty;

    [Required]
    [Display(Name = "متن مقاله")]
    public string Content { get; set; } = string.Empty;

    [Display(Name = "تصویر")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "نویسنده")]
    public string? Author { get; set; }

    [Display(Name = "تاریخ انتشار")]
    public DateTime PublishDate { get; set; } = DateTime.Now;

    [Display(Name = "زمان مطالعه (دقیقه)")]
    public int ReadingTime { get; set; }

    [Required]
    [Display(Name = "دسته بندی")]
    public long BlogCategoryId { get; set; }

    [Display(Name = "منتشر شود")]
    public bool IsPublished { get; set; }

    // SEO

    public string Slug { get; set; } = string.Empty;

    public string SeoTitle { get; set; } = string.Empty;

    public string SeoDescription { get; set; } = string.Empty;

    public string SeoKeywords { get; set; } = string.Empty;

    public string CanonicalUrl { get; set; } = string.Empty;

    public string Robots { get; set; } = "index,follow";
}
