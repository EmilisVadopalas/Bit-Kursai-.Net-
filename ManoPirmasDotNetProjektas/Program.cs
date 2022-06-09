using ManoPirmasDotNetProjektas.Paskaitos.Exeptions;
using ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using ManoPirmasDotNetProjektas.Paskaitos.Networking;
using ManoPirmasDotNetProjektas.Paskaitos.OPP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
    .ConfigureServices((host, services) =>
    {
        var config = host.Configuration;
        
        //Clase parenkama is appsettings.json
        //services.AddSingleton(typeof(ILoggerServise), Type.GetType(config.GetRequiredSection("logger").Value));
        
        //klase parenkama cia
        services.AddSingleton<ILoggerServise, LoggerServise>();     
        
        //Clase parenkama is appsettings.json
        //services.AddScoped( typeof(ITema) , Type.GetType(config.GetRequiredSection("Executor").Value));        
        
        //klase parenkama cia
        services.AddScoped<ITema, NetworkExecutor>();
    })
    .Build();

await host.Services.GetRequiredService<ITema>().Run();

