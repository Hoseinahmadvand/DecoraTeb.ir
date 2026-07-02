
using DecoraTeb.Data.Entities;

public class TeamMember : BaseEntity
{
    public string FullName { get; set; }
    public string JobTitle { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Instagram { get; set; }
    public string Linkedin { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }



}