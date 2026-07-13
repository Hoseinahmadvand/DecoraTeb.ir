namespace DecoraTeb.Data.Entities;

public class Service : SeoEntity
{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string Description { get; set; }
   // public string Image { get; set; }
    public string Icon { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }

}

