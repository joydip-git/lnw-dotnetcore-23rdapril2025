using LnW.DotNet.PmsApp.Repository;
using LnW.DotNet.PmsApp.UserInterface;
using LnW.DotNet.PmsApp.UserInterface.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

StartUp startUp = new();
IHost host = startUp.BuildHostForApp(args);

startUp.Start += new StartUpEventHandler(CallWhenStartsUp);
startUp.OnStart(host.Services);

host.Run();
host.Dispose();

static void CallWhenStartsUp(IServiceProvider sp)
{
    var scope = sp.CreateScope();
    var container = scope.ServiceProvider;
    var manager = container.GetRequiredService<UiManager>();
    manager.RunApp();
    scope.Dispose();
}




