namespace DecoraTeb.Data.Entities;

public class ProjectImsge : BaseEntity
{
    public long ProjectId { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Alt { get; set; }
    public int SortOrder { get; set; }
}
