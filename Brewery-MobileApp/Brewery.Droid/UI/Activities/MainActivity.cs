using Android.Views;
using Android.Views.InputMethods;
using Brewery.Droid.UI.Fragments;
using AndroidX.AppCompat.App;
using Plugin.CurrentActivity;

namespace Brewery.Droid.UI.Activities;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
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

    public void ShowToolbar()
    {
        SupportActionBar.Show();
    }
    
    public void HideToolbar()
    {
        SupportActionBar.Hide();
    }
    
    public void SetToolbarTitle(string text)
    {
        SupportActionBar.Title = text;
    }

    public void SetToolbarBack(bool hasBack)
    {
        SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
    }
    
    public void HideKeyboard()
    {
        var inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
        var currentFocus = CurrentFocus;
        if (currentFocus != null)
        {
            inputMethodManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }

    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        if (item.ItemId == Android.Resource.Id.Home)
        {
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
            }
            else
            {
                Finish();
            }
            return true;
        }

        return base.OnOptionsItemSelected(item);
    }
}