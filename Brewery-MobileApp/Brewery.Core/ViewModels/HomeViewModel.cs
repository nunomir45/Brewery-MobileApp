using System.Collections.ObjectModel;
using Brewery.Core.Services.Interfaces.Business;

namespace Brewery.Core.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly IBreweryService _breweryService;
    
    public EventHandler ShowBreweryDetail; 
    
    public HomeViewModel(IBreweryService breweryService)
    {
        _breweryService = breweryService;
    }
    
    #region Bindings

    public string Title { get; set; }
    
    private ObservableCollection<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery> _breweriesList;
    
    public ObservableCollection<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery> BreweriesList
    {
        get { return _breweriesList; }
        set
        {
            if (_breweriesList != value)
            {
                _breweriesList = value;
                RaisePropertyChanged(nameof(BreweriesList));
            }
        }
    }

    #endregion
    
    public override void Appearing()
    {
        LoadData();
    }

    public override void Disappearing()
    {
    }

    public void SelectBrewery(int position)
    {
        _breweryService.SelectBrewery(position);
        
        if (_breweryService.BrewerySelected != null)
        {
            ShowBreweryDetail?.Invoke(null, EventArgs.Empty);
        }
    }
    
    private void LoadData()
    {
        BreweriesList = new ObservableCollection<Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery>(_breweryService.BreweriesList);
    }
}