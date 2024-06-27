using Brewery.Core.Services.Interfaces.WebService;
using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.Services.Interfaces.Business
{
	public interface IBreweryService
	{
		void SelectBrewery(Guid id);
		Task<Response<DTOs.ListBreweriesOutput>> LoadBreweries();

		List<DTOs.Brewery> GetBreweriesList { get; }

		DTOs.Brewery GetBrewerySelected { get; }
	}
}

