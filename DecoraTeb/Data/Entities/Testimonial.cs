namespace DecoraTeb.Data.Entities;

public class Testimonial : BaseEntity
{
    public string FullName { get; set; }
    public string jobTitle { get; set; }
    public string Comment { get; set; }
    public string Image { get; set; }
    public int Rate { get; set; }
    public int   OrderSort { get; set; }
    public bool IsActive { get; set; }
}




