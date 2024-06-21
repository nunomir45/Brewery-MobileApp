using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.ViewModels;

public class SplashViewModel : BaseViewModel
{
    private readonly IListBreweriesRequest _listBreweriesRequest;
    public SplashViewModel(IListBreweriesRequest listBreweriesRequest)
    {
        _listBreweriesRequest = listBreweriesRequest;
        
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
        /*try
        {
            var response = await _listBreweriesRequest.SendAsync(new ListBreweriesInput());
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }*/
        
        
        string apiUrl = "https://api.openbrewerydb.org/v1/breweries?per_page=3";

        using (var client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); 

                string content = await response.Content.ReadAsStringAsync();

                var breweries = new ListBreweriesOutput(content);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro na solicitação: {e.Message}");
            }
        }
    }

    private async Task ShowNextPage()
    {
        await Task.Delay(3000);
        ShowHome?.Invoke(null, EventArgs.Empty);
    }
}