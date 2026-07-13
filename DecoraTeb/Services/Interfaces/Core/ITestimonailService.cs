using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.Testimonial;

namespace DecoraTeb.Services.Interfaces.Core;

public interface ITestimonialService : ICrudService<Testimonial>
{
    Task<List<TestimonialVm>> GetAllAsync();

    Task<TestimonialVm?> GetByIdAsync(long id);

    Task<Testimonial?> GetEntityByIdAsync(long id);

    Task<List<TestimonialVm>> GetActiveAsync();

    Task<bool> CreateAsync(CreateTestimonialVm model);

    Task<bool> UpdateAsync(UpdateTestimonialVm model);

    Task<bool> DeleteAsync(long id);
}


