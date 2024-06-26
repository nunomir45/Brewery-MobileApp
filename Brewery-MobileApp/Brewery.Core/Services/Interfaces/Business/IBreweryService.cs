using Brewery.Core.Services.Interfaces.WebService;
using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.Services.Interfaces.Business
{
	public interface IBreweryService
	{
		void SelectBrewery(int position);
		Task<Response<DTOs.ListBreweriesOutput>> LoadBreweries();

		List<DTOs.Brewery> GetBreweriesList();

		DTOs.Brewery GetBrewerySelected();
	}
}

