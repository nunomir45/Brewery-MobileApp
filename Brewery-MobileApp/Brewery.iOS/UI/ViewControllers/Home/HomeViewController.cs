using System;
using Brewery.Core.ViewModels;
using Brewery.iOS.UI.Cells;
using Brewery.iOS.UI.ViewControllers.BreweryDetail;
using UIKit;
using Foundation;
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
        _viewModel.ShowBreweryDetail += ShowBreweryDetail;
    }
    
    protected override void CleanUpBindings()
    {
        _viewModel.ShowBreweryDetail -= ShowBreweryDetail;
    }

    #region UI
    
    private void SetUI()
    {
        Title.Text = "Brewery Application";
        
        TableView.RegisterNibForCellReuse(BreweryCell.Nib, BreweryCell.Key);
        TableView.DataSource = this;
        TableView.Delegate = this;
    }

    public IntPtr RowsInSection(UITableView tableView, IntPtr section)
    {
        return _viewModel.BreweriesList?.Count ?? 0;
    }
    
    [Export("tableView:didSelectRowAtIndexPath:")]
    public void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        _viewModel.SelectBrewery(indexPath.Row);
    }

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
        var breweryCell = tableView.DequeueReusableCell(nameof(BreweryCell)) as BreweryCell;
        breweryCell.Configure(_viewModel.BreweriesList[indexPath.Row].Name);
        return breweryCell;
    }
    
    #endregion

    #region Events

    private void ShowBreweryDetail(object? sender, EventArgs e)
    {
        PushViewController("BreweryDetail", nameof(BreweryDetailViewController));
    }

    #endregion
}