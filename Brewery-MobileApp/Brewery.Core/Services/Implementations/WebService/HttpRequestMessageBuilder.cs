using Brewery.Core.Services.Interfaces.WebService;

namespace Brewery.Core.Services.Implementations.WebService;

public class HttpRequestMessageBuilder : IHttpRequestMessageBuilder
{
    private HttpMethod httpMethod;
    private Uri uri;
    private HttpContent content;
    private Dictionary<string, string> requestHeaders;

    public HttpRequestMessage Build()
    {
        var requestMessage = new HttpRequestMessage
        {
            Method = httpMethod,
            RequestUri = uri,
            Content = content,
        };
        
        return requestMessage;
    }

    public IHttpRequestMessageBuilder SetContent(HttpContent content)
    {
        this.content = content;
        return this;
    }

    public IHttpRequestMessageBuilder SetMethod(HttpMethod method)
    {
        this.httpMethod = method;
        return this;
    }

    public IHttpRequestMessageBuilder SetRequestHeader(Dictionary<string, string> headers)
    {
        requestHeaders = headers;
        return this;
    }

    public IHttpRequestMessageBuilder SetUri(Uri uri)
    {
        this.uri = uri;
        return this;
    }
}