using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using System.ComponentModel;
using Brewery.Core.ViewModels;
using Brewery.iOS.UI.Cells;
using Brewery.iOS.UI.ViewControllers.BreweryDetail;
using ObjCRuntime;

namespace Brewery.iOS.UI.ViewControllers.Home;

[Register("HomeViewController")]
public partial class HomeViewController : BaseViewController<HomeViewModel>, IUITableViewDelegate, IUITableViewDataSource
{
    public HomeViewController(NativeHandle handle) : base(handle)
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        SetUI();
    }

    protected override void SetUpBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.ShowBreweryDetail += ShowBreweryDetail;
            _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
            _viewModel.RaisePropertyChanged(nameof(_viewModel.BreweriesList));
        }
    }

    protected override void CleanUpBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.ShowBreweryDetail -= ShowBreweryDetail;
            _viewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        }
    }

    #region UI
    
    private void SetUI()
    {
        Title = _viewModel.Title;

        TableView.RegisterNibForCellReuse(BreweryCell.Nib, BreweryCell.Key);
        TableView.DataSource = this;
        TableView.Delegate = this;
        SearchBar.Delegate = new SearchBarDelegate(this);
    }

    private void UpdateTable()
    {
        TableView.ReloadData();
    }

    #endregion

    #region Events

    private void ShowBreweryDetail(object? sender, EventArgs e)
    {
        PushViewController("BreweryDetail", nameof(BreweryDetailViewController));
    }
    
    private void SearchBarOnTextChanged(object? sender, UISearchBarTextChangedEventArgs e)
    {
        var searchText = e.SearchText?.ToLower();

        _viewModel.FilterBreweriesList(searchText);
       
    }
    
    private void ViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_viewModel.BreweriesList)
            || e.PropertyName == nameof(_viewModel.BreweriesFilteredList))
        {
            UpdateTable();
        }
    }

    #endregion
    
    #region TableView

    public IntPtr RowsInSection(UITableView tableView, IntPtr section)
    {
        return _viewModel.BreweriesFilteredList?.Count ?? 0;
    }
    
    [Export("tableView:didSelectRowAtIndexPath:")]
    public void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        _viewModel.SelectBrewery(indexPath.Row);
    }

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
        var breweryCell = tableView.DequeueReusableCell(nameof(BreweryCell)) as BreweryCell;
        breweryCell.Configure(_viewModel.BreweriesFilteredList[indexPath.Row].Name);
        return breweryCell;
    }
    
    [Export("scrollViewWillBeginDragging:")]
    public void ScrollViewWillBeginDragging(UIScrollView scrollView)
    {
        // Hide keyboard when scrolling
        View.EndEditing(true);
    }
    
    private class SearchBarDelegate : UISearchBarDelegate
    {
        private readonly HomeViewController controller;

        public SearchBarDelegate(HomeViewController controller)
        {
            this.controller = controller;
        }

        public override void TextChanged(UISearchBar searchBar, string searchText)
        {
            controller.SearchBarOnTextChanged(searchBar, new UISearchBarTextChangedEventArgs(searchText));
        }
    }

    #endregion
    
   
}