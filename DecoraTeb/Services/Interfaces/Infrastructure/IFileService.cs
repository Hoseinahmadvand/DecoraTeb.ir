namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface IFileService
{
    Task<string> UploadAsync(IFormFile file, string folder);
    Task DeleteAsync(string path);
}


