using Android.Runtime;
using Android.Util;
using AndroidX.Lifecycle;
using Autofac;
using Brewery.Core;
using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.Droid.Services;
using Plugin.CurrentActivity;

namespace Brewery.Droid;

[Application]
public class Application : Android.App.Application, ILifecycleObserver
{
    private App App { get; set; }
    
    protected Application(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
	    
    }

    public override void OnCreate()
    {
        base.OnCreate();
        ApplicationSetup();
        
        CrossCurrentActivity.Current.Init(this);
        ProcessLifecycleOwner.Get().Lifecycle.AddObserver(this);
    }
    
    private void ApplicationSetup()
    {
        App = new App();
        var builder = App.StartRegistration();
        
#if DEBUG
        Log.WriteLine(LogPriority.Info, "ApplicationSetup", "Start ApplicationSetup");
#endif

        PlatformServiceRegistration(builder);

        App.FinishRegistration(builder);
    }
    
    // Register Platform specific files here
	private void PlatformServiceRegistration(ContainerBuilder builder)
	{
		builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
	}
	
	public override void OnTerminate()
	{
		base.OnTerminate();
	}
}