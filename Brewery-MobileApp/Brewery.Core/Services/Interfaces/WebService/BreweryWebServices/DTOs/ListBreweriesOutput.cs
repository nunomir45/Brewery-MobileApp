using Newtonsoft.Json;

namespace Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

public class ListBreweriesOutput : BaseListOutput<Brewery>
{
    public ListBreweriesOutput(string content) : base(content)
    {
    }
}

public class Brewery
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("brewery_type")]
    public string BreweryType { get; set; }
    
    [JsonProperty("address_1")]
    public string Address1 { get; set; }
    
    [JsonProperty("address_2")]
    public string Address2 { get; set; }
    
    [JsonProperty("address_3")]
    public string Address3 { get; set; }
    
    [JsonProperty("city")]
    public string City { get; set; }
    
    [JsonProperty("state_province")]
    public string StateProvince { get; set; }
    
    [JsonProperty("postal_code")]
    public string PostalCode { get; set; }
    
    [JsonProperty("country")]
    public string Country { get; set; }
    
    [JsonProperty("longitude")]
    public string Longitude { get; set; }
    
    [JsonProperty("latitude")]
    public string Latitude { get; set; }
    
    [JsonProperty("phone")]
    public string Phone { get; set; }
    
    [JsonProperty("website_url")]
    public string WebsiteUrl { get; set; }
    
    [JsonProperty("state")]
    public string State { get; set; }
    
    [JsonProperty("street")]
    public string Street { get; set; }
}