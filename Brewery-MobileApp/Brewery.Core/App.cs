using Autofac;
using Brewery.Core.ViewModels;

namespace Brewery.Core;

public class App
{
    public static IContainer Container { get; set; }

    /// <summary>
    /// Register services for all the application.
    /// This Method needs to be called on the plattform side
    /// All platform service should be register after this method
    /// </summary>
    public ContainerBuilder StartRegistration()
    {
        var builder = new ContainerBuilder();

        RegisterViewModels(builder);
        RegisterServices(builder);

        return builder;
    }
    
    public void FinishRegistration(ContainerBuilder builder)
    {
        Container = builder.Build();
    }

    private void RegisterViewModels(ContainerBuilder builder)
    {
        builder.RegisterType<SplashViewModel>().InstancePerDependency();
        builder.RegisterType<HomeViewModel>().InstancePerDependency();
        builder.RegisterType<BreweryDetailViewModel>().InstancePerDependency();
    }
    
    private void RegisterServices(ContainerBuilder builder)
    {
        
    }
}