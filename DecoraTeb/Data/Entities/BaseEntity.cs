namespace DecoraTeb.Data.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; }= DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }=true;
    public DateTime? DeletedAt { get; set; }
}
