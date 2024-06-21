namespace Brewery.Core.Services.Interfaces.WebService;

public interface IHttpClientService
{
    HttpClient GetClient(string client = null);
}