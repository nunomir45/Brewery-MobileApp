using System.Diagnostics;
using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.WebService;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.Services.Implementations.Business
{
	public class BreweryService : IBreweryService
	{
		private readonly IListBreweriesRequest _listBreweriesRequest;
		private List<DTOs.Brewery> _breweriesList;
		private DTOs.Brewery _brewerySelected;
		
		public List<DTOs.Brewery> GetBreweriesList => _breweriesList;
		public DTOs.Brewery GetBrewerySelected => _brewerySelected;

		public BreweryService(IListBreweriesRequest listBreweriesRequest)
		{
			_listBreweriesRequest = listBreweriesRequest;
		}

		public void SelectBrewery(Guid id)
		{
			if (_breweriesList?.Count > 0)
			{
				_brewerySelected = _breweriesList.FirstOrDefault(x => x.Id == id);
			}
		}

		public async Task<Response<ListBreweriesOutput>> LoadBreweries()
		{
			Response<ListBreweriesOutput> response = null;
			try
			{
				response = await _listBreweriesRequest.SendAsync(new ListBreweriesInput());
				_breweriesList = new List<DTOs.Brewery>(response.Data.DataList);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}

			return response;
		}
	}
}

