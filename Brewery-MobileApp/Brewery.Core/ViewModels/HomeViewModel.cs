using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;

namespace Brewery.Core.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly IBreweryService _breweryService;
    
    public EventHandler ShowBreweryDetail; 
    
    public HomeViewModel(IBreweryService breweryService)
    {
        _breweryService = breweryService;

        Title = "Breweries list";
        
        LoadData();
    }
    
    #region Bindings

    public string Title { get; set; }

    public List<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesList { get;set; }
    public List<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesFilteredList { get;set; }

    #endregion
    
    public override void Appearing()
    {
    }

    public override void Disappearing()
    {
    }

    public void SelectBrewery(int position)
    {
        _breweryService.SelectBrewery(position);
        
        if (_breweryService.GetBrewerySelected() != null)
        {
            ShowBreweryDetail?.Invoke(null, EventArgs.Empty);
        }
    }
    
    private void LoadData()
    {
        var breweriesList = _breweryService.GetBreweriesList() ?? new List<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery>();
        BreweriesList = new List<DTOs.Brewery>(breweriesList);
        BreweriesFilteredList = new List<DTOs.Brewery>(breweriesList);
    }
}