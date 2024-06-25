namespace Brewery.Core.Services.Interfaces.WebService;

public class Error
{
    public Error(string message)
    {
        Message = message;
    }
    
    public virtual string Message { get; private set; }
}