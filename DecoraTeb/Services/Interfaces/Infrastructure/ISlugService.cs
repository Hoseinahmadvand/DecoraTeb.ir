using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface ISlugService
{
    string Generate(string text);
    Task<string> GenerateUniqueAsync<T>(string text)
        where T : SeoEntity;

}


