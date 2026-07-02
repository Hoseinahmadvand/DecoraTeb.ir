namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface IImageService
{
    Task<string> SaveAsync(IFormFile file, string folder);

    Task DeleteAsync(string filename);
    Task<string> ResizeAsync(
        IFormFile file,
        string folder,
        int width,
        int height);
}


