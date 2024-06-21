namespace Brewery.Core.Services.Interfaces.WebService;

public interface IWebServiceRequester
{
    Task<Response<TObject>> RequestAsync<TObject>(HttpClient client, Uri uri, HttpRequestMessage httpRequestMessageFactory, IDeserializer deserializer, bool checkStatusCode = true);
}