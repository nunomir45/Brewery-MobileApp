using System.Reflection;
using Brewery.Core.Resources;
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
        var brewerySelected = _breweryService.GetBrewerySelected;
        BreweryFields = new Dictionary<string, string>();

        if (brewerySelected == null) return;

        if (!string.IsNullOrEmpty(brewerySelected.Name))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Name_Text, brewerySelected.Name);
        }

        if (!string.IsNullOrEmpty(brewerySelected.BreweryType))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Type_Text, brewerySelected.BreweryType);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Address1))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Address_Text, brewerySelected.Address1);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Address2))
        {
            BreweryFields.Add("       ", brewerySelected.Address2);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Address3))
        {
            BreweryFields.Add("       ", brewerySelected.Address3);
        }

        if (!string.IsNullOrEmpty(brewerySelected.City))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_City_Text, brewerySelected.City);
        }

        if (!string.IsNullOrEmpty(brewerySelected.StateProvince))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_StateProvince_Text, brewerySelected.StateProvince);
        }

        if (!string.IsNullOrEmpty(brewerySelected.PostalCode))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_PostalCode_Text, brewerySelected.PostalCode);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Longitude))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Longitude_Text, brewerySelected.Longitude);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Latitude))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Latitude_Text, brewerySelected.Latitude);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Phone))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Phone_Text, brewerySelected.Phone);
        }

        if (!string.IsNullOrEmpty(brewerySelected.WebsiteUrl))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Website_Text, brewerySelected.WebsiteUrl);
        }

        if (!string.IsNullOrEmpty(brewerySelected.State))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_State_Text, brewerySelected.State);
        }

        if (!string.IsNullOrEmpty(brewerySelected.Street))
        {
            BreweryFields.Add(BreweryDictionary.BreweryDetailViewModel_Brewery_Street_Text, brewerySelected.Street);
        }

        RaisePropertyChanged(nameof(BreweryFields));
    }
}