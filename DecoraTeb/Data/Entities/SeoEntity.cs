namespace DecoraTeb.Data.Entities;

public class SeoEntity: BaseEntity
{
    public string Slug { get; set; }
    public string SeoTitle { get; set; }

    public string SeoDescription { get; set; }

    public string SeoKeywords { get; set; }

    public string CanonicalUrl { get; set; }

    public string Robots { get; set; }
}

public class Partner : BaseEntity 
{


}
