using Brewery.Core.Services.Interfaces.CrossPlatform;

namespace Brewery.iOS.Services;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string title, string message, string buttonText, Action buttonAction = null)
    {
        var tcs = new TaskCompletionSource<bool>();

        var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

        alertController.AddAction(UIAlertAction.Create(buttonText, UIAlertActionStyle.Default, 
            action =>
            {
                buttonAction?.Invoke();
                tcs.SetResult(true);
            }));

        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);

        return tcs.Task;
    }
}