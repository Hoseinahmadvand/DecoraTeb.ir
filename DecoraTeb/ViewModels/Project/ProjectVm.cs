using DecoraTeb.ViewModels.ProjectCategory;
using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.Project;

public class ProjectVm : SeoVm
{

    public long Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }

    public string Description { get; set; }



    public string CoverImage { get; set; }
    public string Location { get; set; }
    public int Area { get; set; }
    public string ExecutionYear { get; set; }
    public string ClientName { get; set; }
    public bool IsFeatured { get; set; }
    public int SortOrder { get; set; }
    public ProjectCategoryVm Category { get; set; }
    public long ProjectCategoryId { get; set; }
    public string CategoryTitle { get; set; }
}
public class CreateProjectVm : ProjectFormVm
{
}

public class UpdateProjectVm : ProjectFormVm
{
    public long Id { get; set; }

    public string? CurrentThumbnail { get; set; }

    public string? CurrentCoverImage { get; set; }
}
public class FilterProjectVm
{
    public string Title { get; set; }

    public long? CategoryId { get; set; }

    public bool? IsFeatured { get; set; }

    public int PageId { get; set; } = 1;
}


public class ProjectFormVm : SeoVm
{
    public long Id { get; set; }
    [Required]
    public string Title { get; set; }

    public string Summary { get; set; }

    public string Description { get; set; }



    public IFormFile? CoverImage { get; set; }
    // گالری
    public List<IFormFile>? GalleryImages { get; set; }
    public string? Location { get; set; }

    public int Area { get; set; }

    public string? ExecutionYear { get; set; }

    public string? ClientName { get; set; }

    public bool IsFeatured { get; set; }

    public int SortOrder { get; set; }

    public long ProjectCategoryId { get; set; }
}


public class ProjectDetailVm
{
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public string Summary { get; set; } = "";

    public string Description { get; set; } = "";

    public string CoverImage { get; set; } = "";

    public string Category { get; set; } = "";

    public string Location { get; set; } = "";

    public int Area { get; set; }

    public string ExecutionYear { get; set; }

    public string ClientName { get; set; } = "";

    public List<ProjectImageVm> Gallery { get; set; } = new();

    public List<ProjectCardVm> RelatedProjects { get; set; } = new();
}

public class ProjectCardVm
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string CoverImage { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public int Area { get; set; } 

    public string ExecutionYear { get; set; }

    public bool IsFeatured { get; set; }
}

