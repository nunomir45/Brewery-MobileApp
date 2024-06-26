using System.Diagnostics;
using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.WebService;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Newtonsoft.Json;

namespace Brewery.Core.Services.Implementations.Business
{
	public class BreweryService : IBreweryService
	{
		private readonly IListBreweriesRequest _listBreweriesRequest;
		private List<DTOs.Brewery> _breweriesList;
		private DTOs.Brewery _brewerySelected;

		public BreweryService(IListBreweriesRequest listBreweriesRequest)
		{
			_listBreweriesRequest = listBreweriesRequest;
		}
		
		public void SelectBrewery(int position)
		{
			if (position < _breweriesList?.Count())
			{
				_brewerySelected = _breweriesList[position];
			}
		}

		public async Task<Response<ListBreweriesOutput>> LoadBreweries()
		{
			Response<ListBreweriesOutput> response = null;
			try
			{
				response = await _listBreweriesRequest.SendAsync(new ListBreweriesInput());
				_breweriesList = new List<Interfaces.WebService.BreweryWebServices.DTOs.Brewery>(response.Data.DataList);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
			
			return response;
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

