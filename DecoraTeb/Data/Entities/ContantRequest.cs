namespace DecoraTeb.Data.Entities;

public class ContantRequest : BaseEntity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string subject { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
}
