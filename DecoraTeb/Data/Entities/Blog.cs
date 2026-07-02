namespace DecoraTeb.Data.Entities;

public class Blog : SeoEntity

{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public string Author { get; set; }
    public DateTime PublishDate { get; set; }
    public int ReadingTime { get; set; }

    public long BlogCategoryId { get; set; }
    public bool IsPublished { get; set; }

} 
