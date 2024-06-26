using Autofac;
using Brewery.Core;
using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.iOS.Services;
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
        
        // Create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        Window = new UIWindow(frame: UIScreen.MainScreen.Bounds)
        {
            BackgroundColor = UIColor.White
        };

        var splashViewController = UIStoryboard.FromName("Splash", null)
            .InstantiateInitialViewController();

        var navigationController = new UINavigationController(splashViewController);
		
        Window.MakeKeyAndVisible();
        Window.RootViewController = navigationController;
        
        // Make the window visible
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
    
    // Register Platform specific services here
    private void PlatformServiceRegistration(ContainerBuilder builder)
    {
        builder.RegisterType<DialogService>().As<IDialogService>();
    }
}