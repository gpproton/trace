using System.Reflection;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Trace.ServiceDefaults.Extensions;

public static class GraphqlHelperExtension {
    private static IEnumerable<Type> DiscoverObjectExtensions(this Assembly assembly) {
        return assembly.GetTypes()
        .Where(x => x.CustomAttributes
        .Any(y => y.AttributeType == typeof(ExtendObjectTypeAttribute)));
    }

    public static IRequestExecutorBuilder RegisterObjectExtensions(this IRequestExecutorBuilder requestExecutorBuilder,
        Assembly assembly) {
        var extensionTypes = DiscoverObjectExtensions(assembly);

        foreach (var type in extensionTypes)
            requestExecutorBuilder.AddTypeExtension(type);

        return requestExecutorBuilder;
    }
}