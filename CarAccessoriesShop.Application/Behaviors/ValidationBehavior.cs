using CarAccessoriesShop.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace CarAccessoriesShop.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.SelectMany(result => result.Errors).Where(failure => failure is not null).ToList();

            if (failures.Any())
            {
                throw new ValidationAppException(failures.Select(f => f.ErrorMessage));
            }
        }
        return await next();
    }
}
