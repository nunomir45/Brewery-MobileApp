using Brewery.Core.Services.Interfaces.CrossPlatform;
using Plugin.CurrentActivity;

namespace Brewery.Droid.Services;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string title, string message, string buttonText, Action buttonAction = null)
    {
        var tcs = new TaskCompletionSource<bool>();

        Activity context = CrossCurrentActivity.Current.Activity;
            
        if (context == null)
        {
            tcs.SetResult(false);
            return tcs.Task;
        }

        context.RunOnUiThread(() =>
        {
            var builder = new AlertDialog.Builder(context);
            builder.SetTitle(title);
            builder.SetMessage(message);
            builder.SetPositiveButton(buttonText, (sender, args) =>
            {
                buttonAction?.Invoke();
                tcs.SetResult(true);
            });
            builder.Show();
        });

        return tcs.Task;
    }
}
