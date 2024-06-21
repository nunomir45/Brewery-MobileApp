using Android.Views;
using Autofac;
using Brewery.Core;
using Brewery.Core.ViewModels;
using Brewery.Droid.Helpers;

namespace Brewery.Droid.UI.Fragments;

public class SplashFragment : BaseFragment
{
    private SplashViewModel _viewModel { get; set; }
    
    private TextView _title;
    
    public override List<BaseViewModel> CreateViewModels()
    {
        _viewModel = App.Container.Resolve<SplashViewModel>();
        return new List<BaseViewModel> { _viewModel };
    }
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Splash, container, false);

        _title = view.FindViewById<TextView>(Resource.Id.title);

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
        Activity.Window.ClearFlags(WindowManagerFlags.Fullscreen);
    }

    protected override void SetupBindings()
    {
        _viewModel.ShowHome += ShowHome;
    }

    protected override void CleanupBindings()
    {
        _viewModel.ShowHome -= ShowHome;
    }

    #region Events

    private void ShowHome(object sender, EventArgs e)
    {
        var homeFragment = new HomeFragment();
        this.ShowNewFragment(homeFragment);
    }

    #endregion
    
    #region UI

    private void SetupUI()
    {
        _title.Text = _viewModel.Title;
    }
    
    #endregion
}