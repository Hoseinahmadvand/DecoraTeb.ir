namespace DecoraTeb.Services.Interfaces.Infrastructure;

public interface ISeoService
{
    string GenerateTitle(string title);
    string GenerateDescription(string description);
    string GenerateCanonical(string url);

}


