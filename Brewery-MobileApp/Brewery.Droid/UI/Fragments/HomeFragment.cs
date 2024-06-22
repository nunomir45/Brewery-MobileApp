using System.ComponentModel;
using Android.Views;
using Autofac;
using Brewery.Core;
using Brewery.Core.ViewModels;
using AndroidX.RecyclerView.Widget;
using Brewery.Droid.Helpers;
using Brewery.Droid.UI.Activities;
using Brewery.Droid.UI.Adapters;
using Plugin.CurrentActivity;

namespace Brewery.Droid.UI.Fragments;

public class HomeFragment : BaseFragment
{
    private HomeViewModel _viewModel;
    private MainActivity _activity;
    private RecyclerView _breweriesRecyclerView;
    private BreweriesRecyclerViewAdapter _breweriesRecyclerViewAdapter;
    
    public override List<BaseViewModel> CreateViewModels()
    {
        _viewModel = App.Container.Resolve<HomeViewModel>();
        return new List<BaseViewModel> { _viewModel };
    }
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Home, container, false);

        _breweriesRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.breweriesRecyclerView);

        _activity = (MainActivity)CrossCurrentActivity.Current.Activity;
        
        return view;
    }

    protected override void SetupBindings()
    {
        _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
        _viewModel.ShowBreweryDetail += ShowBreweryDetail;
        _viewModel.RaisePropertyChanged(nameof(_viewModel.BreweriesList));
        
        _activity.SetToolbarTitle(_viewModel.Title);
        _activity.SetToolbarBack(false);
        _activity.ShowToolbar();
    }

    protected override void CleanupBindings()
    {
        _viewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        _viewModel.ShowBreweryDetail -= ShowBreweryDetail;
    }

    #region UI

    private void SetBreweriesRecyclerView()
    {
        if (_viewModel.BreweriesList != null && _viewModel.BreweriesList.Count > 0)
        {
            var _layoutManager = new LinearLayoutManager(this.Context, LinearLayoutManager.Vertical, false);
            _breweriesRecyclerView.SetLayoutManager(_layoutManager);
            _breweriesRecyclerViewAdapter = new BreweriesRecyclerViewAdapter();
            _breweriesRecyclerViewAdapter.ItemClick = ItemClick;
            _breweriesRecyclerViewAdapter.Breweries = new List<Core.Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery>(_viewModel.BreweriesList);

            _breweriesRecyclerView.SetAdapter(_breweriesRecyclerViewAdapter);
            _breweriesRecyclerViewAdapter.NotifyDataSetChanged();
        }
    }
    
    #endregion


    #region Events

    private void ItemClick(int position)
    {
        _viewModel.SelectBrewery(position);
    }
    
    private void ShowBreweryDetail(object sender, EventArgs e)
    {
        var breweryFragment = new BreweryDetailFragment();
        this.ShowNewFragment(breweryFragment, true);
    }
    
    private void ViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        this.RunOnUI(() =>
        {
            if (e.PropertyName == nameof(_viewModel.BreweriesList))
            {
                SetBreweriesRecyclerView();
            }
        });
    }

    #endregion
}