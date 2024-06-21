using Brewery.Core.Services.Interfaces.WebService;
using Newtonsoft.Json;

namespace Brewery.Core.Services.Implementations.WebService.JSONSerializer;

public class JSONDeserializer : IDeserializer
{
    public string ContentType => "application/json";

    public async Task<TObject> DeserializeAsync<TObject>(HttpContent content)
    {
        using (var contentStream = await content.ReadAsStreamAsync())
        {
            using (StreamReader sr = new StreamReader(contentStream))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<TObject>(reader);
            }
        }
    }
}