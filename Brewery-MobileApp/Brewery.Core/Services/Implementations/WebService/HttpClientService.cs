
using System.Net;
using Brewery.Core.Services.Interfaces.WebService;
using ModernHttpClient;

namespace Brewery.Core.Services.Implementations.WebService;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _defaultClient;


    public HttpClientService()
    {
        ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

        var nativeHandler = new NativeMessageHandler(
            throwOnCaptiveNetwork: true,
            tLSConfig: new TLSConfig()
        );
        _defaultClient = new HttpClient(nativeHandler);
        _defaultClient.Timeout = TimeSpan.FromMinutes(1);
    }

    public HttpClient GetClient(string client = null)
    {
        return _defaultClient;
    }
}