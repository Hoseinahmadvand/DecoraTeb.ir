namespace DecoraTeb.Data.Entities;
public class Project : SeoEntity
{ 
    public string Title { get; set; }
    public string Summary { get; set; }

    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string Location { get; set; }
    public int Area { get; set; }
    public string ExecutionYear { get; set; }
    public string ClientName { get; set; }
    public bool IsFeatured { get; set; }
    public int SortOrder { get; set; }
    public long ProjectCategoryId { get; set; }
  
    public ProjectCategory Category { get; set; }
    public ICollection<ProjectImage> Images { get; set; } = new List<ProjectImage>();
}

