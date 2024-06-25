using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.Core.Services.Interfaces.WebService;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.WebService.JSONSerializer;
using IDeserializer = Brewery.Core.Services.Interfaces.WebService.IDeserializer;

namespace Brewery.Core.Services.Implementations.WebService.BreweryWebServices;

public class ListBreweriesRequest : BaseRequest<ListBreweriesInput, ListBreweriesOutput>, IListBreweriesRequest
{
    public ListBreweriesRequest(IWebServiceRequester requester, ISerializer serializer, IDeserializer deserializer, IHttpClientService hpptClientService, IHttpRequestMessageBuilder httpRequestMessageBuilder, IReachabilityService reachabilityService) : base(requester, deserializer, hpptClientService, serializer, reachabilityService, httpRequestMessageBuilder)
    {
    }

    protected override string BsWebMethod => "/v1/breweries";
    protected override bool IsListOutput => true;

    public Task<Response<ListBreweriesOutput>> SendAsync(ListBreweriesInput input)
    {
        return base.SendAsync(input, HttpMethod.Get);
    }
}