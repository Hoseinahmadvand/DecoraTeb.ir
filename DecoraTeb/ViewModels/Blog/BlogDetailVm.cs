namespace DecoraTeb.ViewModels.Blog;

public class BlogDetailVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }

    public int ReadingTime { get; set; }

    public List<string> Tags { get; set; } = [];

    public List<BlogCardVm> RelatedBlogs { get; set; } = [];
}
public class BlogCardVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public DateTime PublishDate { get; set; }

    public int ReadingTime { get; set; }

    public int ViewCount { get; set; }
}
