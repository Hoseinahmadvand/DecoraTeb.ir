namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface IFileService
{
    Task<string> UploadAsync(IFormFile file, string folder);
    Task DeleteAsync(string path);
}

public class FileService : IFileService
{
    public Task DeleteAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadAsync(IFormFile file, string folder)
    {
        throw new NotImplementedException();
    }
}


