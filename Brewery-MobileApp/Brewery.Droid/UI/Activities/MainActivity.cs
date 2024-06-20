using Brewery.Droid.UI.Fragments;
using AndroidX.AppCompat.App;
using Plugin.CurrentActivity;

namespace Brewery.Droid.UI.Activities;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    public string InitialFragment { get; set; }
    
    private Bundle _savedInstanceState;
    
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        System.Diagnostics.Debug.WriteLine("--------- InitialActivity created");

        CrossCurrentActivity.Current.Init(this, savedInstanceState);
        
        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        _savedInstanceState = savedInstanceState;
        
        if (FindViewById(Resource.Id.fragment_container) != null)
        {
            if (_savedInstanceState != null)
            {
                return;
            }

            var fragmentTx = SupportFragmentManager.BeginTransaction();

            //Get initial Fragment
            var fragment = new SplashFragment();
            System.Diagnostics.Debug.WriteLine($"--------- fragment: {fragment.GetType().ToString()}");
            fragmentTx.Replace(Resource.Id.fragment_container, fragment);
            fragmentTx.CommitAllowingStateLoss();
        }
    }
}