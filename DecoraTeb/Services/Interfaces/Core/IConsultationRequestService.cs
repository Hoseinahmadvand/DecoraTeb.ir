using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;

public interface IConsultationRequestService
{
    Task CreateAsync(ConsultationRequest entity);
    Task<List<ConsultationRequest>> GetAllAsync();
    Task<ConsultationRequest?> GetByIdAsync(long id);

    Task MarkAsReadAsync(long id);
    Task DeleteAsync(long id);
}


