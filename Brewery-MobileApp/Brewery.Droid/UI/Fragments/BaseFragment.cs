
using Brewery.Core.ViewModels;

namespace Brewery.Droid.UI.Fragments;

public abstract class BaseFragment : AndroidX.Fragment.App.Fragment
{
    private List<BaseViewModel> ViewModels { get; } = new List<BaseViewModel>();
    public override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetupViewModels();
    }
    
    public override void OnResume()
    {
        base.OnResume();
        foreach (BaseViewModel vm in ViewModels)
        {
            vm.Appearing();
            vm.PropertyChanged += OnPropertyChanged;
        }

        SetupBindings();
    }

    public override void OnPause()
    {
        base.OnPause();
        foreach (BaseViewModel vm in ViewModels)
        {
            vm.Disappearing();
            vm.PropertyChanged -= OnPropertyChanged;
        }
        CleanupBindings();
    }

    public override void OnDestroy()
    {
        base.OnDestroyView();
        CleanViewModels();
    }
    
    protected abstract void SetupBindings();

    protected abstract void CleanupBindings();
    
    public void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
    }
    
    #region ViewModels 

    private void SetupViewModels()
    {
        var viewModels = CreateViewModels();
        AddViewModels(viewModels);
    }

    public abstract List<BaseViewModel> CreateViewModels();

    private void AddViewModels(List<BaseViewModel> viewModels)
    {
        if (viewModels != null)
        {
            foreach (var viewModel in viewModels)
            {
                AddViewModel(viewModel);
            }
        }
    }

    private void AddViewModel(BaseViewModel viewModel)
    {
        ViewModels.Add(viewModel);
    }

    private void CleanViewModels()
    {
        ViewModels.Clear();
    }

    #endregion
}