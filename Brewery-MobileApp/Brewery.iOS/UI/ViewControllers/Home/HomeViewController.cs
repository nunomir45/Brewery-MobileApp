using System;
using Brewery.Core.ViewModels;
using Brewery.iOS.UI.Cells;
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
    }

    protected override void CleanUpBindings()
    {
    }

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

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
        var membersCell = tableView.DequeueReusableCell(nameof(BreweryCell)) as BreweryCell;
        membersCell.Configure(_viewModel.BreweriesList[indexPath.Row].Name);
        return membersCell;
    }
}