using Brewery.iOS.UI.ViewControllers;

namespace Brewery.iOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        Window = new UIWindow(frame: UIScreen.MainScreen.Bounds)
        {
            BackgroundColor = UIColor.White
        };

        var vc = UIStoryboard.FromName("Splash", null)
            .InstantiateInitialViewController();

        var mainController = new MainViewController(vc);
		
        Window.MakeKeyAndVisible();
        Window.RootViewController = mainController;

        // make the window visible
        Window.MakeKeyAndVisible ();


        return true;
    }
}