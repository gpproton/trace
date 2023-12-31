using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Trace.Application;

public static class DependencyInjection {
    public static IServiceCollection RegisterService(this IServiceCollection services, Assembly assembly) {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
