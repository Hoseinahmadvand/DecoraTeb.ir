using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Testimonial;

public class TestimonialVm
{
    public long Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string JobTitle { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int Rate { get; set; }

    public bool IsActive { get; set; }

    public int SortOrder { get; set; }
}
public class TestimonialFormVm
{
    public long Id { get; set; }

    [Display(Name = "نام")]
    [Required]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "سمت")]
    public string JobTitle { get; set; } = string.Empty;

    [Display(Name = "نظر مشتری")]
    [Required]
    public string Comment { get; set; } = string.Empty;

    public string? Image { get; set; }

    [Display(Name = "تصویر")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "امتیاز")]
    [Range(1, 5)]
    public int Rate { get; set; } = 5;

    [Display(Name = "ترتیب")]
    public int SortOrder { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; } = true;
}
public class CreateTestimonialVm : TestimonialFormVm
{
}
public class UpdateTestimonialVm : TestimonialFormVm
{
}
public class TestimonialListVm
{
    public long Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int Rate { get; set; }

    public bool IsActive { get; set; }

    public int SortOrder { get; set; }
}


public class FilterTestimonialVm
{
    public string? FullName { get; set; }

    public bool? IsActive { get; set; }

    public List<TestimonialListVm> Testimonials { get; set; } = [];
}