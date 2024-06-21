using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.ViewModels;

public class SplashViewModel : BaseViewModel
{
    private readonly IListBreweriesRequest _listBreweriesRequest;
    private readonly IBreweryService _breweryService;
    
    public SplashViewModel(IListBreweriesRequest listBreweriesRequest, IBreweryService breweryService)
    {
        _listBreweriesRequest = listBreweriesRequest;
        _breweryService = breweryService;
        
        Title = "Welcome to the Brewery App!";
    }

    #region Bindings

    public string Title { get; set; }
    public event EventHandler ShowHome;

    #endregion
    
    public override void Appearing()
    {
        LoadBreweries();
        ShowNextPage();
    }

    public override void Disappearing()
    {
    }

    private async Task LoadBreweries()
    {
        try
        {
            await _breweryService.LoadBreweries();
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        } 
    }

    private async Task ShowNextPage()
    {
        await Task.Delay(3000);
        ShowHome?.Invoke(null, EventArgs.Empty);
    }
}