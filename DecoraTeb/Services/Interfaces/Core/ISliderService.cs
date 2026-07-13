using DecoraTeb.Data.Entities;
using DecoraTeb.ViewModels.Slider;

namespace DecoraTeb.Services.Interfaces.Core;

public interface ISliderService : ICrudService<Slider>
{
    Task<List<SliderListVm>> GetAllAsync();

    Task<SliderVm?> GetByIdAsync(long id);

    Task<bool> CreateAsync(CreateSliderVm model);

    Task<bool> UpdateAsync(UpdateSliderVm model);

    Task<bool> DeleteAsync(long id);


    // سایت
    Task<List<SliderVm>> GetActiveSliderAsync();
    Task<List<SliderVm>> GetActiveAsync();
}


