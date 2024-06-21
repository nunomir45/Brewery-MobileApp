using System;
using Brewery.Core.ViewModels;
using Brewery.iOS.UI.ViewControllers.Home;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace Brewery.iOS.UI.ViewControllers.Splash;

[Register("SplashViewController")]
public partial class SplashViewController : BaseViewController<SplashViewModel>
{
    public SplashViewController(NativeHandle handle) : base(handle)
    {
    }

    public override async void ViewDidLoad()
    {
        base.ViewDidLoad();
        
        SetupUI();
    }

    protected override void SetUpBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.ShowHome += ShowHome;
        }
    }

    protected override void CleanUpBindings()
    {
        if (_viewModel != null)
        {
            _viewModel.ShowHome -= ShowHome;
        }
    }

    #region UI

    private void SetupUI()
    {
        SplashTitle.Text = _viewModel.Title;
    }
    
    #endregion
    
    #region Events

    private void ShowHome(object sender, EventArgs e)
    {
        PushViewController("Home", nameof(HomeViewController));
    }

    #endregion
}