using AndroidX.AppCompat.App;
using Plugin.CurrentActivity;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace Brewery.Droid.Helpers;

public static class FragmentHelper
{
    public static void ShowNewFragment(this Fragment fragment, Fragment newFrag, bool addToBackStack = false, bool addToView = false, string tag = null)
    {
#if DEBUG
        if (fragment == null)
        {
            throw new ArgumentNullException(nameof(fragment), "fragment can not be null");
        }
        if (fragment.Activity == null)
        {
            throw new ArgumentNullException(nameof(fragment.Activity), "Activity can not be null");
        }
#endif
           
        fragment?.Activity?.RunOnUiThread(() =>
        {
            if (fragment != null
                && fragment.Activity != null
                && !fragment.Activity.IsFinishing
                && !fragment.Activity.IsDestroyed
                && !fragment.Activity.SupportFragmentManager.IsDestroyed)
            {
                var fragmentTx = fragment.Activity.SupportFragmentManager.BeginTransaction();
                var _tag = tag ?? newFrag.Tag;
                if (addToBackStack)
                {
                    if (addToView)
                    {
                        fragmentTx.Add(Resource.Id.fragment_container, newFrag);
                    }
                    else
                    {
                        fragmentTx.Replace(Resource.Id.fragment_container, newFrag);
                    }
                    fragmentTx.AddToBackStack(_tag);
                }
                else
                {
                    fragmentTx.Replace(Resource.Id.fragment_container, newFrag);
                }

                fragmentTx.CommitAllowingStateLoss();
            }
        });
    }
    
    public static void RunOnUI(this Fragment fragment, Action action)
    {
        fragment?.Activity?.RunOnUiThread(action);
    }
}