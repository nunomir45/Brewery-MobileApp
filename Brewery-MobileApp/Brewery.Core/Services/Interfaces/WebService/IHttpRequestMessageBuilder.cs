namespace Brewery.Core.Services.Interfaces.WebService;

public interface IHttpRequestMessageBuilder
{
    IHttpRequestMessageBuilder SetMethod(HttpMethod method);
    IHttpRequestMessageBuilder SetUri(Uri uri);
    IHttpRequestMessageBuilder SetContent(HttpContent content);
    IHttpRequestMessageBuilder SetRequestHeader(Dictionary<string, string> headers);

    HttpRequestMessage Build();
}