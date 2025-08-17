using CarAccessoriesShop.Application.Exceptions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CarAccessoriesShop.Application.Behaviors;

public class ExceptionHandlingBehavior<TRquest, TResponse> : IPipelineBehavior<TRquest, TResponse> where TRquest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRquest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch 
        {
            throw;
        }
    }
}
