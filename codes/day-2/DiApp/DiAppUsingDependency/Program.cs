// See https://aka.ms/new-console-template for more information
using DiAppUsingDependency;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

IServiceCollection serviceRegistry = new ServiceCollection();

//ServiceDescriptor repoSvcDescriptor = new ServiceDescriptor(
//    serviceType: typeof(IRepository),
//    implementationType: typeof(Repository),
//    lifetime: ServiceLifetime.Singleton
//    );
//serviceRegistry.Add(repoSvcDescriptor);

serviceRegistry
    .AddSingleton<IRepository, Repository>();

IServiceProvider container = serviceRegistry.BuildServiceProvider();

IRepository? repo = container.GetRequiredService<IRepository>();

Console.WriteLine($"Repository Data: {repo.GetData()}");

