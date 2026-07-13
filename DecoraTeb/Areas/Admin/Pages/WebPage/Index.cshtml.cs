using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.WebPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Areas.Admin.Pages.WebPage
{
    public class IndexModel : PageModel
    {
        private readonly IWebPageService _service;

        public IndexModel(IWebPageService service)
        {
            _service = service;
        }

        public List<WebPageListVm> Pages { get; set; } = [];

        public async Task OnGetAsync()
        {
            Pages = await _service.GetAllAsync();
        }

        public async Task<IActionResult> OnPostChangeStatusAsync(long id)
        {
            await _service.ChangeStatusAsync(id);

            return RedirectToPage();
        }
    }
}
