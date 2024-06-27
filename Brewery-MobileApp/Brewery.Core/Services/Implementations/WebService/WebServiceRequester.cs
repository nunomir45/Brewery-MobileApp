using System.Diagnostics;
using Brewery.Core.Services.Interfaces.WebService;

namespace Brewery.Core.Services.Implementations.WebService;

public class WebServiceRequester : IWebServiceRequester
{
    public async Task<Response<TObject>> RequestAsync<TObject>(HttpClient client,
        Uri uri,
        HttpRequestMessage httpRequestMessage,
        IDeserializer deserializer, bool isListOutput = false)
    {
        TObject returnObject = default(TObject);

        try
        {
            Debug.WriteLine($"uri {uri}");
            Debug.WriteLine($"headers {httpRequestMessage.Headers}");

            var request = GetRequestMessage(httpRequestMessage); 

            using (var response = await client.SendAsync(request).ConfigureAwait(false))
            {
                Debug.WriteLine("Response:");
                Debug.WriteLine(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

                response.EnsureSuccessStatusCode(); // throws an exception if the status code is unsuccessful
                    
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!isListOutput)
                    {
                        var responseObj = deserializer.DeserializeAsync<TObject>(response.Content);
                        return new Response<TObject>(returnObject);
                    }
                    else
                    {
                        // Works for BaseListOutput
                        var constructor = typeof(TObject).GetConstructor(new[] { typeof(string) });
                        if (constructor != null)
                        {
                            returnObject = (TObject)constructor.Invoke(new object[] { responseContent });
                        }
                    
                        return new Response<TObject>(returnObject);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }
        return new Response<TObject>("WebServiceRequester: Something went wrong");
    }

    private HttpRequestMessage GetRequestMessage(HttpRequestMessage httpRequestMessage)
    {
        var requestMessage = new HttpRequestMessage(httpRequestMessage.Method, httpRequestMessage.RequestUri);

        // Only set the content if the method is not GET
        if (httpRequestMessage.Method != HttpMethod.Get)
        {
            requestMessage.Content = httpRequestMessage.Content;
        }

        // Copy the headers
        foreach (var header in httpRequestMessage.Headers)
        {
            requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return requestMessage;
    }
}