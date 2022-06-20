using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;
using ManoPirmasDotNetProjektas.Paskaitos.AdoNet.CustomOrm;
using ManoPirmasDotNetProjektas.Paskaitos.ApiToDB;
using ManoPirmasDotNetProjektas.Paskaitos.EntityFramework;
using ManoPirmasDotNetProjektas.Paskaitos.Linq;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using ManoPirmasDotNetProjektas.Paskaitos.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
    .ConfigureServices((host, services) =>
    {
        var config = host.Configuration;

        //Clase parenkama is appsettings.json
        //services.AddSingleton(typeof(ILoggerServise), Type.GetType(config.GetRequiredSection("logger").Value));

        services.AddDbContext<BookStoreContext>();

        //klase parenkama cia
        services.AddSingleton<ILoggerServise, LoggerServise>();
        services.AddSingleton<AppSettings>();
        services.AddSingleton<DatabaseEngine>();


        //Clase parenkama is appsettings.json
        //services.AddScoped( typeof(ITema) , Type.GetType(config.GetRequiredSection("Executor").Value));        

        //klase parenkama cia
        services.AddScoped<ITema, LinqExecutor>();       
    })
    .Build();

await host.Services.GetRequiredService<ITema>().Run();

