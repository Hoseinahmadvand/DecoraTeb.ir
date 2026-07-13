using DecoraTeb.Data.Entities;

namespace DecoraTeb.ViewModels.WebPage;

public class WebPageVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Content { get; set; }

    public string? BannerImage { get; set; }

    public string? Icon { get; set; }

    public WebPageType Type { get; set; }

    public bool IsActive { get; set; }

    public int SortOrder { get; set; }

    #region SEO

    public string Slug { get; set; } = string.Empty;

    public string SeoTitle { get; set; } = string.Empty;

    public string SeoDescription { get; set; } = string.Empty;

    public string SeoKeywords { get; set; } = string.Empty;

    public string CanonicalUrl { get; set; } = string.Empty;

    #endregion
}
public class WebPageListVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public WebPageType Type { get; set; }

    public bool IsActive { get; set; }

    public int SortOrder { get; set; }
}