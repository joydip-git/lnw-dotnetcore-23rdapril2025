using LnW.DotNet.PmsApp.BusinessLayer.Abstractions;
using LnW.DotNet.PmsApp.BusinessLayer.Implementations;
using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;
using LnW.DotNet.PmsApp.DataAccessLayer.Implementations;
using LnW.DotNet.PmsApp.Models;
using LnW.DotNet.PmsApp.UserInterface.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LnW.DotNet.PmsApp.UserInterface
{
    public delegate void StartUpEventHandler(IServiceProvider serviceProvider);

    public class StartUp
    {
        public event StartUpEventHandler? Start;

        public IHost BuildHostForApp(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            ConfigureServices(builder);
            return builder.Build();
        }

        static void ConfigureServices(HostApplicationBuilder app)
        {
            app.Services.AddScoped<IPmsDao<Product, string>, ProductDao>();
            app.Services.AddScoped<IPmsBo<Product, string>, ProductBo>();
            app.Services.AddScoped<UiManager>();
        }

        //event invoker (triggers the event)
        public void OnStart(IServiceProvider provider)
        {
            Start?.Invoke(provider);
        }
    }
}
