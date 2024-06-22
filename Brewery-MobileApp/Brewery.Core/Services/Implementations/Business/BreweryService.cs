using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.Services.Implementations.Business
{
	public class BreweryService : IBreweryService
	{
		public List<Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesList { get; set; }
		public Interfaces.WebService.BreweryWebServices.DTOs.Brewery BrewerySelected { get; set; }

		public BreweryService()
		{
		}

		public void SelectBrewery(int position)
		{
			if (position < BreweriesList?.Count())
			{
				BrewerySelected = BreweriesList[position];
			}
		}
		
		public async Task LoadBreweries()
		{
			string apiUrl = "https://api.openbrewerydb.org/v1/breweries";

			using (var client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.GetAsync(apiUrl);
					response.EnsureSuccessStatusCode(); 

					string content = await response.Content.ReadAsStringAsync();

					var breweries = new ListBreweriesOutput(content);
					BreweriesList = new List<Interfaces.WebService.BreweryWebServices.DTOs.Brewery>(breweries.DataList);
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine($"Erro na solicitação: {e.Message}");
				}
			}
		}
	}
}

