namespace Brewery.Core.Services.Interfaces.WebService;

public interface IDeserializer
{
    string ContentType { get; }

    Task<TObject> DeserializeAsync<TObject>(HttpContent content);
}