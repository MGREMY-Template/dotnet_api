namespace Domain.Configuration;

using Domain.DataTransferObject;
using Domain.PïpelineBehaviors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public class ValidatorInstaller : IServiceInstaller
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddValidatorsFromAssembly(typeof(Domain.Marker).Assembly);
        _ = services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    public void Install(WebApplication applicationBuilder)
    {
        _ = applicationBuilder.UseExceptionHandler(x =>
        {
            x.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature.Error;

                if (exception is ValidationException validationException)
                {
                    var errors = validationException.Errors.Select(err =>
                    {
                        return err.ErrorMessage;
                    });

                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsJsonAsync(Result.Failure(400, errors.ToArray()));
                }
                else
                {
                    throw exception;
                }
            });
        });
    }
}
