using System.Diagnostics;
using Brewery.Core.Models;
using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.Core.Services.Interfaces.WebService;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.JSONSerializer;
using Polly;
using Polly.Retry;
using IDeserializer = Brewery.Core.Services.Interfaces.WebService.IDeserializer;

namespace Brewery.Core.Services.Implementations.WebService.BreweryWebServices;

public abstract class BaseRequest<TInput, TOutput>
    where TOutput : BaseOutput
    where TInput : BaseInput
{
    protected readonly IWebServiceRequester Requester;
    protected readonly IDeserializer Deserializer;
    protected readonly IHttpClientService HttpClientService;
    protected readonly ISerializer Serializer;
    protected readonly IReachabilityService ReachabilityService;
    protected readonly IHttpRequestMessageBuilder HttpRequestMessageBuilder;
    
    protected abstract string BsWebMethod { get; }
    
    public BaseRequest(IWebServiceRequester requester,
        IDeserializer deserializer,
        IHttpClientService httpClientService,
        ISerializer serializer,
        IReachabilityService reachabilityService,
        IHttpRequestMessageBuilder httpRequestMessageBuilder)
    {
        Requester = requester;
        Deserializer = deserializer;
        HttpClientService = httpClientService;
        Serializer = serializer;
        ReachabilityService = reachabilityService;
        HttpRequestMessageBuilder = httpRequestMessageBuilder;
    }
    
    protected async virtual Task<Response<TOutput>> SendAsync(TInput input,
        HttpMethod httpMethod,
        int retries = 3)
    {
        try
        {
            var uriPath = BaseURL.URL + BsWebMethod;
            Uri uri = new Uri(uriPath);
            
            var hasInternetConnection = await ReachabilityService.HasInternetConnectionAsync(retries);
            
            if (!hasInternetConnection)
            {
                return new Response<TOutput>(false, null, new Error("Por favor conecte-se à internet."));
            }
            
            HttpContent content = null;
            if (Serializer != null)
            {
                content = await Serializer.SerializeAsync(input).ConfigureAwait(false);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(Serializer.ContentType);
            }

            var requestMessage = HttpRequestMessageBuilder.SetMethod(httpMethod)
                .SetContent(content)
                .SetUri(uri)
                .Build();
            var client = HttpClientService.GetClient();

            var response = await GetHttpResponseWithRetriesAsync(client, uri, requestMessage, Deserializer, retries);

            return response;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);

            return new Response<TOutput>("No endpoint connection");
        }
    }
    
    private async Task<Response<TOutput>> GetHttpResponseWithRetriesAsync(HttpClient client,
        Uri uri,
        HttpRequestMessage requestMessage,
        IDeserializer deserializer,
        int retries)
    {
        try
        {
            AsyncRetryPolicy<Response<TOutput>> retryPolicyNeedsTrueResponse = Policy.HandleResult<Response<TOutput>>(b => !b.Successful && !b.SuccessStatusCode).RetryAsync(retries);

            return await retryPolicyNeedsTrueResponse.ExecuteAsync(async () =>
            {
                var response = await Requester.RequestAsync<TOutput>(client, uri, requestMessage, deserializer).ConfigureAwait(false);
                Debug.WriteLine(response.Error?.Message);
                return response;
            });
        }
        catch (ThreadAbortException e)
        {
            Debug.WriteLine("Exception message: {0}", e.Message);
        }

        return new Response<TOutput>("No endpoint connection");
    }
}