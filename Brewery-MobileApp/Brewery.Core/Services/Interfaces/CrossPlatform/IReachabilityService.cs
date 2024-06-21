namespace Brewery.Core.Services.Interfaces.CrossPlatform;

public interface IReachabilityService
{
    Task<bool> HasInternetConnectionAsync(int retries = 3);
}