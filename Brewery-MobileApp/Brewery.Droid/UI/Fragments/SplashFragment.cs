using Android.Views;
using Autofac;
using Brewery.Core;
using Brewery.Core.ViewModels;
using Brewery.Droid.Helpers;
using Brewery.Droid.UI.Activities;
using Plugin.CurrentActivity;

namespace Brewery.Droid.UI.Fragments;

public class SplashFragment : BaseFragment
{
    private SplashViewModel _viewModel;
    private MainActivity _activity;
    
    private TextView _titleTv;
    
    public override List<BaseViewModel> CreateViewModels()
    {
        _viewModel = App.Container.Resolve<SplashViewModel>();
        return new List<BaseViewModel> { _viewModel };
    }
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Splash, container, false);

        _titleTv = view.FindViewById<TextView>(Resource.Id.title);
        
        _activity = (MainActivity)CrossCurrentActivity.Current.Activity;
        _activity.HideToolbar();
        
        SetupUI();
        
        return view;
    }
    
    public override void OnResume()
    {
        base.OnResume();
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    protected override void SetupBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.ShowHome += ShowHome;
        }
    }

    protected override void CleanupBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.ShowHome -= ShowHome;
        }
    }
    
    #region UI

    private void SetupUI()
    {
        _titleTv.Text = _viewModel.Title;
    }
    
    #endregion

    #region Events

    private void ShowHome(object sender, EventArgs e)
    {
        var homeFragment = new HomeFragment();
        this.ShowNewFragment(homeFragment);
    }

    #endregion
}