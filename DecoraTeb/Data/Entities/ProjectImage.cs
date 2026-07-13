namespace DecoraTeb.Data.Entities;

public class ProjectImage : BaseEntity
{
    public long ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    public string Image { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Alt { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool IsCover { get; set; }
}
