using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QebeleEShop.WebApi.PipelineBehaviors;
using System.Reflection;
using FluentValidation;
namespace QebeleEShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        return services;
    }
}
