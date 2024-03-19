using CabaVS.LoveBowl.Application.Behavior;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CabaVS.LoveBowl.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(AssemblyMarker.Assembly);

                configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            })
            .AddValidatorsFromAssembly(AssemblyMarker.Assembly);
    }
}