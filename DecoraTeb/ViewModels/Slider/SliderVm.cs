namespace DecoraTeb.ViewModels.Slider;

public class SliderVm
{
    public long Id { get; set; }


    // Content
    public string Title { get; set; } = string.Empty;

    public string SubTitle { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;


    // Images
    public IFormFile? ImageFile { get; set; }

    public string? Image { get; set; }

    

 

    // Button
    public string ButtonText { get; set; } = string.Empty;

    public string ButtonLink { get; set; } = string.Empty;


    // Settings
    public int SortOrder { get; set; }

    public bool IsActive { get; set; }


    // SEO

    public string Slug { get; set; }

    public string SeoTitle { get; set; } 

    public string SeoDescription { get; set; }

    public string SeoKeywords { get; set; } 

    public string CanonicalUrl { get; set; } 

    public string Robots { get; set; } = "index,follow";


}
public class SliderListVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateAt { get; set; }
}

public class CreateSliderVm : SliderFormVm
{

}
public class UpdateSliderVm : SliderFormVm
{

}public class SliderFormVm : SliderVm
{

}


