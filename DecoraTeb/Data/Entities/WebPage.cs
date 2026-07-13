namespace DecoraTeb.Data.Entities;

public class WebPage : SeoEntity
{
    public string Title { get; set; } = string.Empty;

    public string Heading { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string BannerImage { get; set; } = string.Empty;

    public string ButtonText { get; set; } = string.Empty;

    public string ButtonLink { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool ShowInMenu { get; set; }

    public bool IsActive { get; set; }

    public WebPageType Type { get; set; }
}
public enum WebPageType
{
    Home = 1,

    AboutUs = 2,

    Contact = 3,

    Privacy = 4,

    Terms = 5,

    FAQ = 6
}
