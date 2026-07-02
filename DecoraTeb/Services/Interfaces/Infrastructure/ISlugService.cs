using DecoraTeb.Data.Entities;

namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface ISlugService
{
    string Generate(string text);
    Task<string> GenerateUniqueAsync<T>(string text)
        where T : SeoEntity;

}


public class SlugService : ISlugService
{
    public string Generate(string text)
    {
        throw new NotImplementedException();
    }

    public Task<string> GenerateUniqueAsync<T>(string text) where T : SeoEntity
    {
        throw new NotImplementedException();
    }
}