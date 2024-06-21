using System;
namespace Brewery.Core.Services.Interfaces.Business
{
	public interface IBreweryService
	{
		List<Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesList { get; set; }

		Task LoadBreweries();
	}
}

