namespace DecoraTeb.ViewModels.Service;



public class ServiceListVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;



    public bool IsActive { get; set; }

    public int SortOrder { get; set; }
}
public class FilterServiceVm
{
    public string? Title { get; set; }

    public bool? IsActive { get; set; }

    public List<ServiceListVm> Services { get; set; } = [];
}