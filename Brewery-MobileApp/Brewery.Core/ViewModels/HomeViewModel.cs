using Brewery.Core.Resources;
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

        Title = BreweryDictionary.HomeViewModel_Title_text;
        
        LoadData();
    }
    
    #region Bindings

    public string Title { get; set; }

    public List<DTOs.Brewery> BreweriesList { get;set; }
    public List<DTOs.Brewery> BreweriesFilteredList { get;set; }

    #endregion
    
    public override void Appearing()
    {
    }

    public override void Disappearing()
    {
    }

    public void SelectBrewery(int position)
    {
        if (position < BreweriesFilteredList?.Count)
        {
            _breweryService.SelectBrewery(BreweriesFilteredList[position].Id);
        }
        
        if (_breweryService.GetBrewerySelected != null)
        {
            ShowBreweryDetail?.Invoke(null, EventArgs.Empty);
        }
    }

    public void FilterBreweriesList(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            BreweriesFilteredList = BreweriesList;
        }
        else
        {
            BreweriesFilteredList = BreweriesList.Where(item => item.Name.ToLower().Contains(searchText) || item.Name.ToLower().Contains(searchText)).ToList();
        }
        
        RaisePropertyChanged(nameof(BreweriesFilteredList));
    }
    
    private void LoadData()
    {
        var breweriesList = _breweryService.GetBreweriesList ?? new List<DTOs.Brewery>();
        BreweriesList = new List<DTOs.Brewery>(breweriesList);

        if(BreweriesFilteredList == null)
        {
            BreweriesFilteredList = new List<DTOs.Brewery>(breweriesList);
        }
    }
}