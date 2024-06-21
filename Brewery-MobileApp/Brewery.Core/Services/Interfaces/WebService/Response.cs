namespace Brewery.Core.Services.Interfaces.WebService;

public class Response
{
    public Response(string errorMessage) : this(false, new Error(errorMessage)) { }

    public Response(Exception ex) : this(false, new Error(ex)) { }

    public Response(bool success, string error = null) : this(success, new Error(error)) { }

    public Response(Error error) : this(false, error) { }

    public Response(bool success, Error error)
    {
        Successful = success;
        Error = error;
    }

    public Response(bool success, Error error, bool successStatusCode)
    {
        Successful = success;
        Error = error;
        SuccessStatusCode = successStatusCode;
    }

    public bool Successful { get; private set; }

    public Error Error { get; private set; }

    public bool? _successStatusCode;
    public bool SuccessStatusCode
    {
        get => _successStatusCode ?? Successful;
        private set
        {
            _successStatusCode = value;
        }
    }
}

public class Response<TObject> : Response
{

    public Response(string errorMessage) : base(errorMessage) { }

    public Response(Exception ex) : base(ex) { }

    public Response(bool success, TObject data, Error error)
        : base(success, error)
    {
        Data = data;
    }

    public Response(bool success, TObject data, Error error, bool successStatusCode)
        : base(success, error, successStatusCode)
    {
        Data = data;
    }

    public Response(TObject data)
        : this(success: true, data: data, errorMessage: string.Empty)
    {
    }

    public Response(bool success, TObject data, string errorMessage)
        : this(success, data, new Error(errorMessage))
    {
    }

    public Response(Error error) : base(false, error) { }

    public TObject Data { get; private set; }
}