public static class Startup
{
    public static IServiceCollection AddBaseClassService(this IServiceCollection services)
    {
        var baseClassToScan = new Type[]
        {
            typeof("base class in project"),
            //...
        };

        var concretions = Assembly
            // scan at project executing
            .GetExecutingAssembly()
            .DefinedTypes
            // find baseclas name equal to [baseClassToScan]
            .Where(type => baseClassToScan
                .Select(a => a.Name)
                .Contains(type?.BaseType?.Name))
            .ToList();

        foreach (var type in concretions)
        {
            services.AddTransient(type);
        }

        return services;
    }
}
