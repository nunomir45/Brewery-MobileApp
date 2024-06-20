using Android.Views;

namespace Brewery.Droid.UI.Fragments;

public class BreweryDetailFragment : BaseFragment
{
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.BreweryDetail, container, false);

        
        return view;
    }
}