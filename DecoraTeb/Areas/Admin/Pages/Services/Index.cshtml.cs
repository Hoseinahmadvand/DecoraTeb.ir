using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.Services;

public class IndexModel : PageModel
{
    private readonly IServiceService _service;

    public IndexModel(IServiceService service)
    {
        _service = service;
    }

    public List<ServiceVm> ServiceLists { get; set; }
    public async void OnGet()
    {
        ServiceLists = await _service.GetAllAsync();
    }
}
