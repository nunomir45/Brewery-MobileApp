using System;
using Brewery.Core.ViewModels;
using Brewery.iOS.UI.Cells;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace Brewery.iOS.UI.ViewControllers.BreweryDetail;

[Register("BreweryDetailViewController")]
public partial class BreweryDetailViewController : BaseViewController<BreweryDetailViewModel>, IUITableViewDelegate, IUITableViewDataSource
{
    public BreweryDetailViewController(NativeHandle handle) : base(handle)
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        SetUI();
    }

    protected override void SetUpBindings()
    {

    }

    protected override void CleanUpBindings()
    {

    }
    
    #region UI

    private void SetUI()
    {
        TableView.RegisterNibForCellReuse(BreweryFieldCell.Nib, BreweryFieldCell.Key);
        TableView.DataSource = this;
        TableView.Delegate = this;
    }
    
    #endregion
    
    #region TableView

    public IntPtr RowsInSection(UITableView tableView, IntPtr section)
    {
        return _viewModel.BreweryFields?.Count ?? 0;
    }

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
        var breweryItem = _viewModel.BreweryFields.ElementAt(indexPath.Row);
        var breweryCell = tableView.DequeueReusableCell(nameof(BreweryFieldCell)) as BreweryFieldCell;
        breweryCell.Configure(breweryItem.Key, breweryItem.Value);
        return breweryCell;
    }
    
    #endregion
}