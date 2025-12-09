namespace DependencyInjection;

public class InjectableAttribute(ServiceLifetime lifeTime = ServiceLifetime.Scoped) : Attribute
{
    public ServiceLifetime Lifetime { get; } = lifeTime;
}
