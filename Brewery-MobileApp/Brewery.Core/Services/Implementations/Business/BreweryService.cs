using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.Services.Implementations.Business
{
	public class BreweryService : IBreweryService
	{
		private List<DTOs.Brewery> _breweriesList;
		private DTOs.Brewery _brewerySelected;

		public void SelectBrewery(int position)
		{
			if (position < _breweriesList?.Count())
			{
				_brewerySelected = _breweriesList[position];
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
					_breweriesList = new List<Interfaces.WebService.BreweryWebServices.DTOs.Brewery>(breweries.DataList);
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine($"Erro na solicitação: {e.Message}");
				}
			}
		}
		
		#region GetsAndSets
		
		public List<DTOs.Brewery> GetBreweriesList()
		{
			return _breweriesList;
		}

		public DTOs.Brewery GetBrewerySelected()
		{
			return _brewerySelected;
		} 
		
		#endregion
	}
}

