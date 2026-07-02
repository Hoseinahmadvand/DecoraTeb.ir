namespace DecoraTeb.ViewModels.Blog;

public class BlogListVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Image { get; set; }

    public string? Author { get; set; }

    public DateTime PublishDate { get; set; }

    public bool IsPublished { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}
