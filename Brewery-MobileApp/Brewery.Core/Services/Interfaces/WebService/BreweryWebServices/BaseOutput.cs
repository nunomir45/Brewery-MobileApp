using Newtonsoft.Json;

namespace Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;

public abstract class BaseOutput
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}

public abstract class BaseListOutput<T> : BaseOutput
{
    public List<T> DataList { get; set; }
    public BaseListOutput(string content)
    {
        DataList = JsonConvert.DeserializeObject<List<T>>(content);
    }
}