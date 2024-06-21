using System.ComponentModel;

namespace Brewery.Core.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void RaisePropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private bool _isBusy;
    
    public bool IsBusy
    {
        get { return _isBusy; }
        set { _isBusy = value; RaisePropertyChanged(nameof(IsBusy)); }
    }

    public abstract void Appearing();
    public abstract void Disappearing();
}