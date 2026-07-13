using DecoraTeb.Services;
using DecoraTeb.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages;
//[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IDashboardService _dashboardService;

    public IndexModel(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public DashboardVm Dashboard { get; set; }

    public async Task OnGetAsync()
    {
        Dashboard = await _dashboardService.GetDashboardAsync();
    }
}
