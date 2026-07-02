namespace DecoraTeb.ViewModels.Service;

public class ServiceDetailsVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? Image { get; set; }

    public string? Icon { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }

    public string Slug { get; set; } = string.Empty;

    public string SeoTitle { get; set; } = string.Empty;

    public string SeoDescription { get; set; } = string.Empty;

    public string SeoKeywords { get; set; } = string.Empty;

    public string CanonicalUrl { get; set; } = string.Empty;

    public string Robots { get; set; } = string.Empty;
}
