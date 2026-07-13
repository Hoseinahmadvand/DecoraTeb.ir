using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Project;

public class ProjectImageVm
{
    public long Id { get; set; }

    public long ProjectId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Alt { get; set; } = string.Empty;

    public string? Image { get; set; }

    public IFormFile? File { get; set; }

    public bool IsCover { get; set; }

    public int SortOrder { get; set; }
}

public class CreateProjectImageVm
{
    [Required]
    public long ProjectId { get; set; }

    [Required]
    public IFormFile Image { get; set; }

    public string Name { get; set; }

    public string Alt { get; set; }

    public int SortOrder { get; set; }
}
public class UpdateProjectImageVm : CreateProjectImageVm
{
    public long Id { get; set; }

    public string CurrentImage { get; set; }
}
public class ProjectImageListVm : ProjectImageVm
{
    public bool IsActive { get; set; }
}


