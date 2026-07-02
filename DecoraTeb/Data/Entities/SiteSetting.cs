namespace DecoraTeb.Data.Entities;

public class SiteSetting : BaseEntity
{
    public string SiteName { get; set; }

    public string SiteTitle { get; set; }

    public string SiteDescription { get; set; }

    public string SiteKeywords { get; set; }

    public string Logo { get; set; }

    public string Favicon { get; set; }

    public string Phone { get; set; }

    public string Mobile { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public string Instagram { get; set; }

    public string Telegram { get; set; }

    public string Whatsapp { get; set; }

    public string Linkedin { get; set; }

    public string FooterText { get; set; }

    public string GoogleMap { get; set; }

    public bool IsOpen { get; set; }
}