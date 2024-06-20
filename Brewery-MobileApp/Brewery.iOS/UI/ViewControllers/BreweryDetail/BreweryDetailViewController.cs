using System;

using UIKit;
using Foundation;

namespace Brewery.iOS.UI.ViewControllers.BreweryDetail;

[Register("BreweryDetailViewController")]
public partial class BreweryDetailViewController : UIViewController
{
    public BreweryDetailViewController() : base()
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        // Perform any additional setup after loading the view, typically from a nib.
    }

    public override void DidReceiveMemoryWarning()
    {
        base.DidReceiveMemoryWarning();
        // Release any cached data, images, etc that aren't in use.
    }
}