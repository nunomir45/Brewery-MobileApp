using Android.Views;
using Brewery.Droid.Helpers;

namespace Brewery.Droid.UI.Fragments;

public class SplashFragment : BaseFragment
{
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Splash, container, false);

        
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

    #region Events

    private void ShowHome(object sender, EventArgs e)
    {
        var homeFragment = new HomeFragment();
        this.ShowNewFragment(homeFragment);
    }

    #endregion
}