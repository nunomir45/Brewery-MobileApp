using Brewery.Core.Services.Interfaces.CrossPlatform;
using Plugin.Connectivity;
using Polly;
using Polly.Retry;

namespace Brewery.Core.Services.Implementations.Crossplatform;

public class ReachabilityService : IReachabilityService
{
    public async Task<bool> HasInternetConnectionAsync(int retries = 3)
    {
        if (!CrossConnectivity.IsSupported)
            return true;

        RetryPolicy<Task<bool>> retryPolicyNeedsTrueResponse = Policy.HandleResult<Task<bool>>(b => !b.Result).Retry(retries);

        return await retryPolicyNeedsTrueResponse.Execute(async () =>
        {
            return await Task.FromResult(CrossConnectivity.Current.IsConnected);
        });
    }
}