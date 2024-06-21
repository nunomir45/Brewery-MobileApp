namespace Brewery.Core.ViewModels;

public class SplashViewModel : BaseViewModel
{
    public SplashViewModel()
    {
        Title = "Welcome to the Brewery App!";
    }

    #region Bindings

    public string Title { get; set; }
    public event EventHandler ShowHome;

    #endregion
    
    public override void Appearing()
    {
        ShowNextPage();
    }

    public override void Disappearing()
    {
    }

    private async Task ShowNextPage()
    {
        await Task.Delay(3000);
        ShowHome?.Invoke(null, EventArgs.Empty);
    }
}