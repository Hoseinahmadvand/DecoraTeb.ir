using DecoraTeb.Data.Entities;
using DecoraTeb.Services.Interfaces.Core;

namespace DecoraTeb.Services.Core;

public class ConsultationRequestService : IConsultationRequestService
{
    public Task CreateAsync(ConsultationRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ConsultationRequest>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ConsultationRequest?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task MarkAsReadAsync(long id)
    {
        throw new NotImplementedException();
    }
}


