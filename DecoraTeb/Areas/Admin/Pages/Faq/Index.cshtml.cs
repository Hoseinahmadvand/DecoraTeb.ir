using DecoraTeb.Services.Interfaces.Core;
using DecoraTeb.ViewModels.Faq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace DecoraTeb.Areas.Admin.Pages.Faq;

public class IndexModel : PageModel
{
    private readonly IFaqService _faqService;

    public IndexModel(IFaqService faqService)
    {
        _faqService = faqService;
    }

    public List<FaqVm> Faqs { get; set; } = [];

    [BindProperty]
    public CreateFaqVm CreateModel { get; set; } = new();

    [BindProperty]
    public UpdateFaqVm UpdateModel { get; set; } = new();

    public async Task OnGetAsync()
    {
        await LoadData();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadData();
            return Page();
        }

        var result = await _faqService.CreateAsync(CreateModel);

        if (!result)
        {
            ModelState.AddModelError("", "خطا در ثبت اطلاعات");
            await LoadData();
            return Page();
        }

        TempData["Success"] = "سوال با موفقیت ثبت شد.";

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEditAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadData();
            return Page();
        }

        var result = await _faqService.UpdateAsync(UpdateModel);

        if (!result)
        {
            ModelState.AddModelError("", "خطا در ویرایش اطلاعات");
            await LoadData();
            return Page();
        }

        TempData["Success"] = "ویرایش انجام شد.";

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(long id)
    {
        await _faqService.DeleteAsync(id);

        TempData["Success"] = "آیتم حذف شد.";

        return RedirectToPage();
    }

    private async Task LoadData()
    {
        Faqs = await _faqService.GetAllAsync();
    }
}
