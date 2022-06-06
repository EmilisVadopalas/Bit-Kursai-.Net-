using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
    .ConfigureServices((host, services) =>
    {
        var config = host.Configuration;
        services.AddSingleton(typeof(ILoggerServise), Type.GetType(config.GetRequiredSection("logger").Value));
        services.AddScoped(typeof(ITema), Type.GetType(config.GetRequiredSection("Executor").Value));        
    })
    .Build();

await host.Services.GetRequiredService<ITema>().Run();

