using System.ComponentModel.DataAnnotations;

namespace DecoraTeb.ViewModels.ProjectCategory;

public class ProjectCategoryVm : SeoVm
{
    public long Id { get; set; }

    public string Title { get; set; }

    public int SortOrder { get; set; }
}
public class ProjectCategoryFormVm : SeoVm
{
    public long Id { get; set; }
    [Required]
    [Display(Name = "عنوان")]
    public string Title { get; set; }

    [Display(Name = "ترتیب نمایش")]
    public int SortOrder { get; set; }
}
public class CreateProjectCategoryVm : ProjectCategoryFormVm
{
}
public class UpdateProjectCategoryVm : ProjectCategoryFormVm
{
   
}
public class FilterProjectCategoryVm
{
    public string? Title { get; set; }

    public int PageNumber { get; set; } = 1;

    public int Take { get; set; } = 10;

    public int TotalCount { get; set; }

    public List<ProjectCategoryVm> Categories { get; set; } = [];
}