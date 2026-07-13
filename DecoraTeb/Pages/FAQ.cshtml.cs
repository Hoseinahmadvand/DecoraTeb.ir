using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Faq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecoraTeb.Pages
{
    public class FAQModel : PageModel
    {
        private readonly IFaqService _faqService;

        public FAQModel(IFaqService faqService)
        {
            _faqService = faqService;
        }

        public List<FaqVm> Faqs { get; set; } = [];

        public async Task OnGet()
        {
            Faqs = await _faqService.GetAllAsync();
        }
    }
}
