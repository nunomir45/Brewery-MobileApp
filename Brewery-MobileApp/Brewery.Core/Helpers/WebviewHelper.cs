using Xamarin.Essentials;

namespace Brewery.Core.Helpers;

public static class WebviewHelper
{
    public static async Task OpenUri(string url)
    {
        var uri = new Uri(url);

        await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
}