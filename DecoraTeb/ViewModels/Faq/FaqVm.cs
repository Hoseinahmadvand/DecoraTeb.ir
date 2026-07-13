using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Faq;

public class FaqVm
{
    public long Id { get; set; }

    public string Question { get; set; } = string.Empty;

    public string Answer { get; set; } = string.Empty;

    public int OrderSort { get; set; }

    public bool IsActive { get; set; }
}
public class FaqFormVm
{
    public long Id { get; set; }

    [Display(Name = "سوال")]
    [Required(ErrorMessage = "لطفاً سوال را وارد کنید.")]
    public string Question { get; set; } = string.Empty;

    [Display(Name = "پاسخ")]
    [Required(ErrorMessage = "لطفاً پاسخ را وارد کنید.")]
    public string Answer { get; set; } = string.Empty;

    [Display(Name = "ترتیب نمایش")]
    public int OrderSort { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; } = true;
}
public class FilterFaqVm
{
    public string? Question { get; set; }

    public bool? IsActive { get; set; }

    public List<FaqListVm> Faqs { get; set; } = [];
}
public class FaqListVm
{
    public long Id { get; set; }

    public string Question { get; set; } = string.Empty;

    public int OrderSort { get; set; }

    public bool IsActive { get; set; }
}
public class UpdateFaqVm : FaqFormVm
{
}
public class CreateFaqVm : FaqFormVm
{
}