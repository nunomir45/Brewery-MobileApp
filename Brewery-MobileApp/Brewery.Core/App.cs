using Autofac;
using Brewery.Core.Services.Implementations.Business;
using Brewery.Core.Services.Implementations.Crossplatform;
using Brewery.Core.Services.Implementations.WebService;
using Brewery.Core.Services.Implementations.WebService.BreweryWebServices;
using Brewery.Core.Services.Implementations.WebService.JSONSerializer;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.Core.Services.Interfaces.WebService;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.JSONSerializer;
using Brewery.Core.ViewModels;
using IDeserializer = Brewery.Core.Services.Interfaces.WebService.IDeserializer;

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
        RegisterRequests(builder);

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
        builder.RegisterType<BreweryService>().As<IBreweryService>().SingleInstance();
    }
    
    private void RegisterRequests(ContainerBuilder builder)
    {
        builder.RegisterType<HttpClientService>().As<IHttpClientService>().SingleInstance();
        builder.RegisterType<HttpRequestMessageBuilder>().As<IHttpRequestMessageBuilder>().SingleInstance();
        builder.RegisterType<JSONDeserializer>().As<IDeserializer>().SingleInstance();
        builder.RegisterType<JSONSerializer>().As<ISerializer>().SingleInstance();
        builder.RegisterType<WebServiceRequester>().As<IWebServiceRequester>().SingleInstance();
        builder.RegisterType<ReachabilityService>().As<IReachabilityService>();
        
        // Requests
        builder.RegisterType<ListBreweriesRequest>().As<IListBreweriesRequest>();
    }
}