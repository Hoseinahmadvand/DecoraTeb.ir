using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Service;

public class ServiceVm : SeoVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;



    public bool IsActive { get; set; }

    public int SortOrder { get; set; }
}

public class ServiceFormVm : SeoVm
{
    public long Id { get; set; }

    [Display(Name = "عنوان")]
    [Required]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "توضیح کوتاه")]
    public string ShortDescription { get; set; } = string.Empty;

    [Display(Name = "توضیحات")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "آیکون")]
    public string Icon { get; set; } = string.Empty;

    public string? Image { get; set; }

 

    [Display(Name = "فعال")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "ترتیب")]
    public int SortOrder { get; set; }
}
