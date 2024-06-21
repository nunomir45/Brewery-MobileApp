namespace Brewery.Core.Services.Interfaces.WebService.JSONSerializer;

public interface IDeserializer
{
    string ContentType { get; }

    Task<TObject> DeserializeAsync<TObject>(HttpContent content);
}