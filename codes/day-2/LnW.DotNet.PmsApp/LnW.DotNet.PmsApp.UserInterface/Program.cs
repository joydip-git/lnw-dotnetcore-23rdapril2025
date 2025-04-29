using LnW.DotNet.PmsApp.Repository;
using LnW.DotNet.PmsApp.UserInterface;
using LnW.DotNet.PmsApp.UserInterface.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

StartUp startUp = new();
using (IHost host = startUp.BuildHostForApp(args))
{

    startUp.Start += new StartUpEventHandler(CallWhenStartsUp);
    startUp.OnStart(host.Services);
    await host.RunAsync();    
    //host.Dispose();
}

static async void CallWhenStartsUp(IServiceProvider sp)
{
    using var scope = sp.CreateScope();
    var container = scope.ServiceProvider;
    var manager = container.GetRequiredService<UiManager>();
    await manager.RunApp();
    //scope.Dispose();
}




