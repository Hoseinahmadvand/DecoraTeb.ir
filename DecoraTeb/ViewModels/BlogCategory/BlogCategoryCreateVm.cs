using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.BlogCategory;


public class BlogCategoryCreateVm
{
    [Required(ErrorMessage = "عنوان الزامی است.")]
    [Display(Name = "عنوان")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "ترتیب نمایش")]
    [Range(0, int.MaxValue)]
    public int SortOrder { get; set; }
}

