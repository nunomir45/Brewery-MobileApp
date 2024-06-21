namespace Brewery.Core.Services.Interfaces.WebService.JSONSerializer;

public interface ISerializer
{
    string ContentType { get; }

    Task<HttpContent> SerializeAsync<TObject>(TObject content);
}