namespace DecoraTeb.ViewModels.Service;

public class ServiceListVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Image { get; set; }

    public string? Icon { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }
}