namespace Brewery.Core.Services.Interfaces.CrossPlatform;

public interface IDialogService
{
    Task ShowAlertAsync(string title, string message, string buttonText, Action buttonAction = null);
}