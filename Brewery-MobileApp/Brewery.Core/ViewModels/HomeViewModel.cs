using Brewery.Core.Services.Interfaces.Business;

namespace Brewery.Core.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly IBreweryService _breweryService;

    public List<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesList { get; set; }
    
    public HomeViewModel(IBreweryService breweryService)
    {
        _breweryService = breweryService;
    }
    
    #region Bindings

    public string Title { get; set; }

    #endregion
    
    public override void Appearing()
    {
        LoadData();
    }

    public override void Disappearing()
    {
    }

    private void LoadData()
    {
        BreweriesList = _breweryService.BreweriesList;
    }
}