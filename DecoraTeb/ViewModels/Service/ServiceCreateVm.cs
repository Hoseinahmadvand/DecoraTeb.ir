using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Service;

public class ServiceCreateVm
{
    [Required(ErrorMessage = "عنوان الزامی است.")]
    [Display(Name = "عنوان")]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "خلاصه")]
    [Required(ErrorMessage = "خلاصه الزامی است.")]
    public string Summary { get; set; } = string.Empty;

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "توضیحات الزامی است.")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "تصویر")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "آیکون")]
    public string? Icon { get; set; }

    [Display(Name = "ترتیب نمایش")]
    public int SortOrder { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; }

    // SEO

    public string Slug { get; set; } = string.Empty;

    public string SeoTitle { get; set; } = string.Empty;

    public string SeoDescription { get; set; } = string.Empty;

    public string SeoKeywords { get; set; } = string.Empty;

    public string CanonicalUrl { get; set; } = string.Empty;

    public string Robots { get; set; } = "index,follow";
}
