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

public class ImageService : IImageService
{
    public Task DeleteAsync(string filename)
    {
        throw new NotImplementedException();
    }

    public Task<string> ResizeAsync(IFormFile file, string folder, int width, int height)
    {
        throw new NotImplementedException();
    }

    public Task<string> SaveAsync(IFormFile file, string folder)
    {
        throw new NotImplementedException();
    }
}


