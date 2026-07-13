using DecoraTeb.Data.Entities;

namespace DecoraTeb.ViewModels;

public class SeoVm
{
    public string Slug { get; set; } = string.Empty;

    public string SeoTitle { get; set; } = string.Empty;

    public string SeoDescription { get; set; } = string.Empty;

    public string SeoKeywords { get; set; } = string.Empty;

    public string CanonicalUrl { get; set; } = string.Empty;

    public string Robots { get; set; } = "index,follow";
}
