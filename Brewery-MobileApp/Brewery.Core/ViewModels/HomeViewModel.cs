namespace Brewery.Core.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public HomeViewModel(){}
    
    #region Bindings

    public string Title { get; set; }

    #endregion
    
    public override void Appearing()
    {
    }

    public override void Disappearing()
    {
    }
}