using log4net;
using log4net.Config;
using ManoPirmasDotNetProjektas.Paskaitos;
using ManoPirmasDotNetProjektas.Paskaitos.Colections;
using ManoPirmasDotNetProjektas.Paskaitos.Exeptions;
using ManoPirmasDotNetProjektas.Paskaitos.Generics;
using ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using ManoPirmasDotNetProjektas.Paskaitos.OPP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

//singleton susikuria viena kart ir kai kamnors reikia injectint resursa visada paduoda tapacia klase
//scope susikuria kiekviena kart injectinant 
//transient kiekviena kart kvieciant betkoki metoda naujas referencas

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
    .ConfigureServices((host, services) =>
    {
        if (host.Configuration.GetRequiredSection("logger:logger2:loggerDeep").Value == "test")
        {
            services.AddSingleton<ILoggerServise, BigLoggerServise>();
        }
        else
        {
            services.AddSingleton<ILoggerServise, LoggerServise>();
        }      
        
    }).Build();


//OppExecutor.Run();
//CollectionsExecutor.Run();
GenericsAndEventsExecutor.Run();
//ExeptionExecutor.Run();
await IOExecutor.Run(host.Services);

