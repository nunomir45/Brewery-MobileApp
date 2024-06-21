using Android.Views;
using Autofac;
using Brewery.Core;
using Brewery.Core.ViewModels;

namespace Brewery.Droid.UI.Fragments;

public class HomeFragment : BaseFragment
{
    private HomeViewModel _viewModel;
    
    public override List<BaseViewModel> CreateViewModels()
    {
        _viewModel = App.Container.Resolve<HomeViewModel>();
        return new List<BaseViewModel> { _viewModel };
    }
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Home, container, false);

        
        return view;
    }

    protected override void SetupBindings()
    {
    }

    protected override void CleanupBindings()
    {
    }

    
}