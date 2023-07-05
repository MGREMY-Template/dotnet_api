namespace Domain.PïpelineBehaviors;

using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this._validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = this._validators
            .Select(x =>
            {
                return x.Validate(context);
            })
            .SelectMany(x =>
            {
                return x.Errors;
            })
            .Where(x =>
            {
                return x is not null;
            })
            .ToArray();

        return failures.Any()
            ? throw new ValidationException(failures)
            : next();
    }
}
