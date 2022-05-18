using ManoPirmasDotNetProjektas.Paskaitos.Colections.Array;
using ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus;
using ManoPirmasDotNetProjektas.Paskaitos.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections.Lists
{
    public static class Listai
    {
        public static void ListuPavyzdziai()
        {
            var listas = new List<string>();
            List<int> listas2 = new List<int>();

            var listas3 = new List<BusRoute>(Masyvai.InitializeRoutes());

            listas.Add("pirmas");
            listas.AddRange(new string[] { "antras", "trecias" });

            listas2.Add(1);
            
        }

        public static void AutobusuUzduotisPirma()
        {
            var busRoutes = new List<BusRoute>(Masyvai.InitializeRoutes());

            Console.Write("i kokia stotele norite nuvykti ? ");
            var destination = Console.ReadLine();

            var route = busRoutes.FindBusTo(destination);

            Console.WriteLine(route is null ? $"marsruti i {destination} nera" : $"marsrutas {route.Number} is {route.Origin} per {destination} vyksta i {route.Destination}");
        }

    }
}
