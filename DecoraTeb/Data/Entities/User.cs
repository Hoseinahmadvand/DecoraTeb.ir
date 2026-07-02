
using DecoraTeb.Data.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public bool IsAdmin { get; set; }
    public string Password { get; set; }
}
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