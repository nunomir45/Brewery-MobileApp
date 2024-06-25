
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Brewery.Core.Constants;
using Brewery.Core.Services.Interfaces.WebService;
using ModernHttpClient;

namespace Brewery.Core.Services.Implementations.WebService;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _defaultClient;

    public HttpClientService()
    {
        var nativeHandler = new HttpClientHandler();
        nativeHandler.ServerCertificateCustomValidationCallback += ValidatePubKey;

        _defaultClient = new HttpClient(nativeHandler);
        _defaultClient.Timeout = TimeSpan.FromMinutes(1);
    }

    public HttpClient GetClient(string client = null)
    {
        return _defaultClient;
    }
    
    private bool ValidatePubKey(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        var publicKey = certificate?.GetPublicKeyString();

        bool isValid = CertificatePinningKeys.AllowedPublicKeys?.ContainsValue(publicKey) ?? false;
        
        if (!isValid)
        {
            Debug.WriteLine("Validate public key FAILED!");
            Debug.WriteLine($"{publicKey} not authorized.", true);
        }

        return true;
    }
}