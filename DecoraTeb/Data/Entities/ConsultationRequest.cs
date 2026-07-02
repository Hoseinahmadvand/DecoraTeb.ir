namespace DecoraTeb.Data.Entities;

public class ConsultationRequest:BaseEntity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ProjectType { get; set; }
    public string City { get; set; }
    public string Area { get; set; }
    public string Budget { get; set; }
    public string Description { get; set; }
    public string Status  { get; set; }
    public bool IsAdmin { get; set; }
    public string Attachment { get; set; }
    

}
