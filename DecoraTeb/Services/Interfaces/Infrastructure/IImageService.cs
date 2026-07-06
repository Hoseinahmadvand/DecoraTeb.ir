using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;




namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface IImageService
{
    Task<string> UploadAsync(
        IFormFile file,
        string folder,
        int? width = null,
        int? height = null,
        bool convertToWebp = true);

    Task<string> ReplaceAsync(
        IFormFile? file,
        string? oldImage,
        string folder,
        int? width = null,
        int? height = null);

    Task DeleteAsync(
        string? fileName,
        string folder);

    bool IsImage(IFormFile file);

    bool IsValidSize(
        IFormFile file,
        int maxMb = 5);

    string GenerateFileName(string extension = ".webp");
}




public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _environment;

    public ImageService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> UploadAsync(
        IFormFile file,
        string folder,
        int? width = null,
        int? height = null,
        bool convertToWebp = true)
    {
        if (!IsImage(file))
            throw new Exception("Invalid image.");

        if (!IsValidSize(file))
            throw new Exception("Image size is invalid.");

        var extension = convertToWebp
            ? ".webp"
            : Path.GetExtension(file.FileName);

        var fileName = GenerateFileName(extension);

        var uploadPath = Path.Combine(
            _environment.WebRootPath,
            "uploads",
            folder);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var filePath = Path.Combine(uploadPath, fileName);

        if (convertToWebp)
        {
            using var image = await Image.LoadAsync(file.OpenReadStream());

            if (width.HasValue && height.HasValue)
            {
                image.Mutate(x => x.Resize(width.Value, height.Value));
            }

            await image.SaveAsync(filePath, new WebpEncoder
            {
                Quality = 80
            });
        }
        else
        {
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        return fileName;
    }

    public async Task<string> ReplaceAsync(
        IFormFile? file,
        string? oldImage,
        string folder,
        int? width = null,
        int? height = null)
    {
        if (file == null)
            return oldImage ?? "";

        await DeleteAsync(oldImage, folder);

        return await UploadAsync(
            file,
            folder,
            width,
            height,
            true);
    }

    public Task DeleteAsync(
        string? fileName,
        string folder)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return Task.CompletedTask;

        var filePath = Path.Combine(
            _environment.WebRootPath,
            "uploads",
            folder,
            fileName);

        if (File.Exists(filePath))
            File.Delete(filePath);

        return Task.CompletedTask;
    }

    public bool IsImage(IFormFile file)
    {
        return file.ContentType.StartsWith("image/");
    }

    public bool IsValidSize(
        IFormFile file,
        int maxMb = 5)
    {
        return file.Length <= maxMb * 1024 * 1024;
    }

    public string GenerateFileName(string extension = ".webp")
    {
        return $"{Guid.NewGuid():N}{extension}";
    }
}

