using Brewery.Core.Resources;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;

namespace Brewery.Core.ViewModels;

public class SplashViewModel : BaseViewModel
{
    private readonly IListBreweriesRequest _listBreweriesRequest;
    private readonly IBreweryService _breweryService;
    private readonly IDialogService _dialogService;
    
    public SplashViewModel(IListBreweriesRequest listBreweriesRequest, IBreweryService breweryService, IDialogService dialogService)
    {
        _listBreweriesRequest = listBreweriesRequest;
        _breweryService = breweryService;
        _dialogService = dialogService;

        Title = BreweryDictionary.SplashViewModel_Title_Text;
    }

    #region Bindings

    public string Title { get; set; }
    public event EventHandler ShowHome;

    #endregion
    
    public override async void Appearing()
    {
        await LoadBreweries();
    }

    public override void Disappearing()
    {
    }

    private async Task LoadBreweries()
    {
        try
        {
            var response = await _breweryService.LoadBreweries();

            if (response.Successful)
            {
                await ShowNextPage();
            }
            else
            {
                await _dialogService.ShowAlertAsync(BreweryDictionary.SplashViewModel_ErrorLoadingDataDialog_TitleText, response?.Data?.Message, BreweryDictionary.SplashViewModel_Error_LoadingDataDialog_ButtonText, async ()=> await LoadBreweries());
            }
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        } 
    }

    private async Task ShowNextPage()
    {
        await Task.Delay(2000);
        ShowHome?.Invoke(null, EventArgs.Empty);
    }
}