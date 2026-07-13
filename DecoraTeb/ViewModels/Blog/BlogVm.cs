using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Blog;

public abstract class BlogVm : SeoVm
{
    [Required]
    [MaxLength(300)]
    public string Title { get; set; }
    public string Slug { get; set; }


    [Required]
    public string Summary { get; set; }

    [Required]
    public string Content { get; set; }

    public IFormFile? ImageFile { get; set; }

    public string? Image { get; set; }

    public string Author { get; set; }

    public DateTime PublishDate { get; set; }

    public int ReadingTime { get; set; }

    public long BlogCategoryId { get; set; }

    public bool IsPublished { get; set; }
}


