namespace DecoraTeb.ViewModels.Blog;

public class BlogListItemVm
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Image { get; set; }

    public bool IsPublished { get; set; }

    public DateTime PublishDate { get; set; }
}
