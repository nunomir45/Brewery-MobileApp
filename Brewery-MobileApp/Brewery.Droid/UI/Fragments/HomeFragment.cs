using Android.Views;

namespace Brewery.Droid.UI.Fragments;

public class HomeFragment : BaseFragment
{
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Home, container, false);

        
        return view;
    }
}