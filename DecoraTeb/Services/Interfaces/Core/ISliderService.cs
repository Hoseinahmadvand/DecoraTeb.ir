using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Core;

public interface ISliderService : ICrudService<Slider>
{
    Task<List<Slider>> GetActiveSliderAsync();
}


