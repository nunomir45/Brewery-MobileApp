using System;
using Brewery.iOS.UI.ViewControllers.Home;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace Brewery.iOS.UI.ViewControllers.Splash;

[Register("SplashViewController")]
public partial class SplashViewController : UIViewController
{
    public SplashViewController(NativeHandle handle) : base(handle)
    {
    }

    public override async void ViewDidLoad()
    {
        base.ViewDidLoad();
        
        await Task.Delay(4000);

        ShowFirstViewController();
    }
    
    private void ShowFirstViewController()
    {
        var storyboard = UIStoryboard.FromName("Home", null);
        var viewController = storyboard.InstantiateViewController(nameof(HomeViewController));
        ((MainViewController)ParentViewController)?.Replace(viewController);
    }

    public override void DidReceiveMemoryWarning()
    {
        base.DidReceiveMemoryWarning();
        // Release any cached data, images, etc that aren't in use.
    }
}