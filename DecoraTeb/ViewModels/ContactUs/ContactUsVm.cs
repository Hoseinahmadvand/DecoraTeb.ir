namespace DecoraTeb.ViewModels.ContactUs;

public class ContactUsVm
{
    public long Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public bool IsAnswered { get; set; }

    public DateTime CreateDate { get; set; }
}

public class ContactUsListVm
{
    public long Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string? Subject { get; set; }

    public bool IsRead { get; set; }

    public bool IsAnswered { get; set; }

    public DateTime CreateDate { get; set; }
}
