using System.ComponentModel;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Autofac;
using Brewery.Core;
using Brewery.Core.ViewModels;
using Brewery.Droid.Helpers;
using Brewery.Droid.UI.Activities;
using Brewery.Droid.UI.Adapters;
using Plugin.CurrentActivity;

namespace Brewery.Droid.UI.Fragments;

public class BreweryDetailFragment : BaseFragment
{
    private BreweryDetailViewModel _viewModel;
    private MainActivity _activity;
    private RecyclerView _breweryDetailRecyclerView;
    private BreweryDetailRecyclerViewAdapter _breweryDetailRecyclerViewAdapter;

    public override List<BaseViewModel> CreateViewModels()
    {
        _viewModel = App.Container.Resolve<BreweryDetailViewModel>();
        return new List<BaseViewModel> { _viewModel };
    }
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.BreweryDetail, container, false);

        _breweryDetailRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.breweryDetailRecyclerView);

        _activity = (MainActivity)CrossCurrentActivity.Current.Activity;
        _activity.SetToolbarTitle(_viewModel.BreweryFields["Name"]);
        
        
        return view;
    }
    
    protected override void SetupBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
            _viewModel.RaisePropertyChanged(nameof(_viewModel.BreweryFields));
        }
        
        _activity?.SetToolbarBack(true);
    }

    protected override void CleanupBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        }
        
        _activity?.SetToolbarBack(false);
    }

    #region UI

    private void SetBreweryDetailRecyclerView()
    {
        if (_viewModel.BreweryFields != null && _viewModel.BreweryFields.Count > 0)
        {
            var _layoutManager = new LinearLayoutManager(this.Context, LinearLayoutManager.Vertical, false);
            _breweryDetailRecyclerView.SetLayoutManager(_layoutManager);
            _breweryDetailRecyclerViewAdapter = new BreweryDetailRecyclerViewAdapter();
            _breweryDetailRecyclerViewAdapter.BreweryFields = _viewModel.BreweryFields;

            _breweryDetailRecyclerView.SetAdapter(_breweryDetailRecyclerViewAdapter);
            _breweryDetailRecyclerViewAdapter.NotifyDataSetChanged();
        }
    }
    
    #endregion
    
    #region Events

    private void ViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        this.RunOnUI(() =>
        {
            if (e.PropertyName == nameof(_viewModel.BreweryFields))
            {
                SetBreweryDetailRecyclerView();
            }
        });
    }

    #endregion
}
