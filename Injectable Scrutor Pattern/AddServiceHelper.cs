using Scrutor;

namespace DependencyInjection;

// Note: This class is used to register services with attributes indicating their lifetimes.
// https://github.com/alimozdemir/medium/blob/master/DIScan/attrService/Solution3.cs
public static class AddServiceHelper
{
    public static IImplementationTypeSelector InjectableAttributes(this IImplementationTypeSelector selector)
    {
        var lifeTimes = Enum.GetValues(typeof(ServiceLifetime)).Cast<ServiceLifetime>();

        foreach (var item in lifeTimes)
            selector = selector.InjectableAttribute(item);

        return selector;
    }

    public static IImplementationTypeSelector InjectableAttribute(this IImplementationTypeSelector selector, ServiceLifetime lifeTime)
    {
        return selector.AddClasses(c => c.WithAttribute<InjectableAttribute>(i => i.Lifetime == lifeTime))
            .AsImplementedInterfaces()
            .WithLifetime(lifeTime);
    }
}
