using DecoraTeb.ViewModels.ContactUs;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IContactUsService
{
    Task<List<ContactUsListVm>> GetAllAsync();

    Task<ContactUsVm?> GetByIdAsync(int id);

    Task<bool> ChangeReadStatusAsync(int id);

    Task<bool> ChangeAnsweredStatusAsync(int id);

    Task<bool> DeleteAsync(int id);

    Task<int> GetUnreadCountAsync();

    Task CreateAsync(ContactUsVm model);
}


