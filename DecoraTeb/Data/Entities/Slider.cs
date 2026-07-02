namespace DecoraTeb.Data.Entities;

public class Slider:BaseEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string MobileImage { get; set; }
    public string ButtonText { get; set; }
    public string ButtonLink { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }

}
