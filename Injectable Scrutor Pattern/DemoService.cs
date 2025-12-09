namespace DependencyInjection;

// Note: In Program.cs add...
//       builder.Service.AddServiceHelper();

[Injectable(ServiceLifetime.Scoped)]
public class DemoService
{
}
