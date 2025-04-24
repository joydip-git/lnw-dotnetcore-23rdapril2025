// See https://aka.ms/new-console-template for more information
using DiWithHosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//IServiceCollection serviceRegistry = builder.Services;

//serviceRegistry
//    .AddSingleton<IRepository, Repository>();
builder.Services.AddSingleton<IRepository, Repository>();

//ConfigurationManager configurationManager = builder.Configuration;

var keysAndValues = new Dictionary<string, string>
{
    { "filePath", "path" }
};
//configurationManager
//    .AddJsonFile(@"appsettings.json", false, true)
//    .AddInMemoryCollection(keysAndValues);
builder
    .Configuration
    .AddJsonFile(@"appsettings.json", false, true)
    .AddInMemoryCollection(keysAndValues);


IHost host = builder.Build();

IServiceProvider container = host.Services;
var repo = container.GetRequiredService<IRepository>();
Console.WriteLine(repo?.GetData());

var configDataProvider = container.GetRequiredService<IConfiguration>();
//Console.WriteLine(configDataProvider.GetValue<string>("filePath"));

Console.WriteLine(configDataProvider["filePath"]);

Console.WriteLine(configDataProvider.GetRequiredSection("Profile").Value);

