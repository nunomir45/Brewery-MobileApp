using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace Brewery.iOS.UI.ViewControllers.Home;

[Register("HomeViewController")]
public partial class HomeViewController : UIViewController
{
    public HomeViewController(NativeHandle handle) : base(handle)
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        SetUI();
    }

    private void SetUI()
    {
        Title.Text = "Brewery Application";
    }

    public override void DidReceiveMemoryWarning()
    {
        base.DidReceiveMemoryWarning();
        // Release any cached data, images, etc that aren't in use.
    }
}