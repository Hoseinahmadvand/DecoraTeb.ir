using DecoraTeb.Services;
using DecoraTeb.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHomeService _homeService;

        public IndexModel(ILogger<IndexModel> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public HomeVm Home { get; set; }

        public async Task OnGetAsync()
        {
            Home = await _homeService.GetHomePageAsync();
        }
    }
}
