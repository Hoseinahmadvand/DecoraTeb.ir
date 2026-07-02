namespace DecoraTeb.Data.Entities;
public class Project : SeoEntity
{ 
    public string Title { get; set; }
    public string Summary { get; set; }

    public string Description { get; set; }

    public string Thumnail { get; set; }

    public string CoverImage { get; set; }
    public string Location { get; set; }
    public string Area { get; set; }
    public string ExecutionYear { get; set; }
    public string ClientName { get; set; }
    public bool IsFeatured { get; set; }
    public int SortOrder { get; set; }
    public long ProjectCategoryId { get; set; }

}

