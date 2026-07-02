namespace DecoraTeb.ViewModels.BlogCategory;

public class BlogCategoryListVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }
}

