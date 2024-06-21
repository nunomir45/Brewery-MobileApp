using Brewery.Core.Services.Interfaces.WebService.JSONSerializer;
using Newtonsoft.Json;

namespace Brewery.Core.Services.Implementations.WebService.JSONSerializer;

public class JSONSerializer : ISerializer
{
    public string ContentType => "application/json";

    public async Task<HttpContent> SerializeAsync<TObject>(TObject content)
    {

        HttpContent httpContent = null;
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
        };
        var jsonObject = JsonConvert.SerializeObject(content, jsonSerializerSettings);

#if DEBUG
        System.Diagnostics.Debug.WriteLine($"jsonObject {jsonObject}");
#endif

        httpContent = new StringContent(jsonObject);

        return await Task.FromResult(httpContent);
    }
}