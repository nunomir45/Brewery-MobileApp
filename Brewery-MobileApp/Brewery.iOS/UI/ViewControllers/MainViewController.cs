using System;

using UIKit;
using Foundation;

namespace Brewery.iOS.UI.ViewControllers;

[Register("MainViewController")]
public partial class MainViewController : UIViewController
{
    public MainViewController(UIViewController firstViewController)
    {
        CurrentViewController = firstViewController;
    }

    public UIViewController CurrentViewController { get; private set; }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        if (CurrentViewController != null)
        {
            Show(CurrentViewController);
        }
    }

    public void Show(UIViewController viewController, bool animated = false)
    {
        AddChildViewController(viewController);
        viewController.View.Frame = View.Frame;
        viewController.WillMoveToParentViewController(this);
        View.Add(viewController.View);

        if(animated) View.Alpha = 0;

        viewController.DidMoveToParentViewController(this);
        CurrentViewController = viewController;

        if(animated)
        {
            UIView.Animate(0.2f, () =>
            {
                View.Alpha = 1;
            });
        }
    }

    public void Replace(UIViewController viewController, bool animated = false)
    {
        if (CurrentViewController != null)
        {
            RemoveCurrentViewController();
        }
        Show(viewController, animated);
    }

    public void RemoveCurrentViewController()
    {
        CurrentViewController.WillMoveToParentViewController(null);
        CurrentViewController.View.RemoveFromSuperview();
        CurrentViewController.DidMoveToParentViewController(null);
        CurrentViewController.RemoveFromParentViewController();
        CurrentViewController = ChildViewControllers.LastOrDefault();
    }
}