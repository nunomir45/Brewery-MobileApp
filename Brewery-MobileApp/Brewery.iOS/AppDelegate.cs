using Autofac;
using Brewery.Core;
using Brewery.iOS.UI.ViewControllers;

namespace Brewery.iOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }
    
    private App App { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        ApplicationSetup();
        
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
    
    private void ApplicationSetup()
    {
        App = new Core.App();
        var builder = App.StartRegistration();
        PlatformServiceRegistration(builder);
        App.FinishRegistration(builder);
    }
    
    //Register Platform specific services here
    private void PlatformServiceRegistration(ContainerBuilder builder)
    {
    }
}