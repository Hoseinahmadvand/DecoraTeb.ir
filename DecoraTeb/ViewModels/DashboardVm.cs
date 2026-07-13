namespace DecoraTeb.ViewModels;

public class DashboardVm
{
    public int ProjectCount { get; set; }

    public int BlogCount { get; set; }

    public int ServiceCount { get; set; }

    public int MessageCount { get; set; }

    public int SliderCount { get; set; }

    public int FaqCount { get; set; }

    public int TestimonialCount { get; set; }

    public List<DashboardProjectVm> LatestProjects { get; set; } = new();

    public List<DashboardBlogVm> LatestBlogs { get; set; } = new();
}
public class DashboardProjectVm
{
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }
}

public class DashboardBlogVm
{
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public DateTime CreateDate { get; set; }
}