namespace DecoraTeb.ViewModels.Blog;

public class BlogDetailsVm:BlogListVm
{
    public string Summary { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int ReadingTime { get; set; }

    public string Slug { get; set; } = string.Empty;

    public string SeoTitle { get; set; } = string.Empty;

    public string SeoDescription { get; set; } = string.Empty;

    public string SeoKeywords { get; set; } = string.Empty;
}
