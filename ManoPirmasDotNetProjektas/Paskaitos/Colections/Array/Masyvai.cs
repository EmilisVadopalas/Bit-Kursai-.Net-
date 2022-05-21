using ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus;
using System;
using ManoPirmasDotNetProjektas.Paskaitos.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections.Array
{
    public static class Masyvai
    {
        public static void MasyvaiTesting()
        {
            var routes = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(routes[routes.Length - 1]);
            Console.WriteLine(routes[^1]);
            Console.WriteLine(routes[^2]);
            Console.WriteLine(routes[^3]);
        }

        public static void AutobusuUzduotis()
        {
            var busRoutes = InitializeRoutes();

            Console.Write("i kokia stotele norite nuvykti ? ");
            var destination = Console.ReadLine();

            var route = busRoutes.FindBusTo(destination);

            Console.WriteLine(route is null ? $"marsruti i {destination} nera": $"marsrutas {route.Number} is {route.Origin} per {destination} vyksta i {route.Destination}");
        }

        public static BusRoute[] InitializeRoutes()
        {
            var route1 = new string[] { "Urmo turgus", "Ozo gatve", "Centras", "Svytrigailos gatve", "Vilniaus gatve", "Kauno gatve", "Kauno ligonine" };
            var route2 = new string[] { "Meno gimnazija", "Moletu gatve", "Apylinke", "Svytrigailos gatve", "Vilniaus gatve", "Kauno gatve", "Partizanu gatve" };
            var route3 = new string[] { "stotele1", "stotele2", "stotele3", "stotele4", "stotele5" };
            var route4 = new string[] { "stotele3", "stotele4", "stotele5", "stotele6", "stotele7", "stotele8", "stotele9", "stotele2", "stotele1" };
            
            return new BusRoute[]
            {
                new BusRoute("A40", route1),
                new BusRoute("A37", route2),
                new BusRoute("A28", route3),
                new BusRoute("A57G", route4),
            };
        }
    }
}
