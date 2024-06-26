using System.Reflection;
using Brewery.Core.Services.Interfaces.Business;

namespace Brewery.Core.ViewModels;

public class BreweryDetailViewModel : BaseViewModel
{
    private readonly IBreweryService _breweryService;
    public Dictionary<string, string> BreweryFields { get; set; }
    
    public BreweryDetailViewModel(IBreweryService breweryService)
    {
        _breweryService = breweryService;

        LoadDictionary();
    }
    
    public override void Appearing()
    {
    }

    public override void Disappearing()
    {
    }

    private void LoadDictionary()
    {
        BreweryFields = new Dictionary<string, string>();
        
        // Get all properties of Brewery
        PropertyInfo[] properties = typeof(Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        if (properties == null || properties.Length == 0) return;
        
        foreach (var property in properties)
        {
            var brewerySelected = _breweryService.GetBrewerySelected();
            // Get property value
            var value = property.GetValue(brewerySelected);

            if (value != null)
            {
                BreweryFields[property.Name] = value.ToString();
            }
        }
        
        RaisePropertyChanged(nameof(BreweryFields));
    }
}