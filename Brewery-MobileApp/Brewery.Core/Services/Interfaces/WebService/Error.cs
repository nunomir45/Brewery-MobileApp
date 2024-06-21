namespace Brewery.Core.Services.Interfaces.WebService;

public class Error
{
    public Error(string message)
    {
        Message = message;
    }

    public Error(Exception ex) : this(ex.Message) { }

    public static Error Empty { get; internal set; } = new Error("Empty Message");
    public virtual string Message { get; private set; }
}