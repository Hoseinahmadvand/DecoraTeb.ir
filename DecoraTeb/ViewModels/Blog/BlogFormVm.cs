using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Blog;

public class BlogFormVm : SeoVm
{
    public long Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Summary { get; set; }

    public string Content { get; set; }

    public IFormFile? ImageFile { get; set; }

    public string? Image { get; set; }

    public long BlogCategoryId { get; set; }

    public string Author { get; set; }

    public DateTime PublishDate { get; set; }

    public int ReadingTime { get; set; }

    public bool IsPublished { get; set; }
}