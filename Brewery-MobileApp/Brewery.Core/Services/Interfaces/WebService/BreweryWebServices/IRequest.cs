namespace Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;

public interface IRequest<TInput, TOutput>
    where TInput : BaseInput
    where TOutput : BaseOutput
{
    Task<Response<TOutput>> SendAsync(TInput input);
}