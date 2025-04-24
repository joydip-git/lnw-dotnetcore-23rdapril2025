using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Service Lifetime!!!");

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<ServiceLifetimeReporter>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();

IHost host = builder.Build();
ReportServiceLifetime(host.Services, "Scope-1");
ReportServiceLifetime(host.Services, "Scope-2");

host.Run();

host.Dispose();

static void ReportServiceLifetime(IServiceProvider provider, string lifetime)
{
    IServiceScope scope = provider.CreateScope();

    var container = scope.ServiceProvider;
    Console.WriteLine($"{lifetime}-Call-1");
    var reporter = container.GetRequiredService<ServiceLifetimeReporter>();
    reporter.Report();

    Console.WriteLine("\n\n");

    Console.WriteLine($"{lifetime}-Call-2");
    reporter = container.GetRequiredService<ServiceLifetimeReporter>();
    reporter.Report();

    scope.Dispose();
}


class ServiceLifetimeReporter(
    ISingletonService singleton,
    IScopedService scoped,
    ITransientService transient
    )
{

    public void Report()
    {
        LogService<ISingletonService>(singleton);
        LogService<IScopedService>(scoped);
        LogService<ITransientService>(transient);
    }
    private static void LogService<T>(T service) where T : IService => Console.WriteLine($"{service.Id}:{service.Lifetime}");
}
interface IService
{
    Guid Id { get; }
    ServiceLifetime Lifetime { get; }
}

interface ISingletonService : IService
{
    ServiceLifetime IService.Lifetime { get => ServiceLifetime.Singleton; }
}
interface IScopedService : IService
{
    ServiceLifetime IService.Lifetime => ServiceLifetime.Scoped;
}
interface ITransientService : IService
{
    ServiceLifetime IService.Lifetime => ServiceLifetime.Transient;
}
class SingletonService : ISingletonService
{
    public Guid Id { get; } = Guid.NewGuid();
}

class ScopedService : IScopedService
{
    public Guid Id { get; } = Guid.NewGuid();
}
class TransientService : ITransientService
{
    public Guid Id { get; } = Guid.NewGuid();
}
