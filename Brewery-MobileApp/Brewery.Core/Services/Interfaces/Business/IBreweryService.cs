using System;
namespace Brewery.Core.Services.Interfaces.Business
{
	public interface IBreweryService
	{
		List<Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesList { get; set; }
		Interfaces.WebService.BreweryWebServices.DTOs.Brewery BrewerySelected { get; set; }

		void SelectBrewery(int position);
		Task LoadBreweries();
	}
}

