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
        public static List<BusRoute> BusRoutes = new List<BusRoute>(Masyvai.InitializeRoutes());

        public static void ListuPavyzdziai()
        {
            var listas = new List<string>();
            List<int> listas2 = new List<int>();

            var listas3 = new List<BusRoute>(Masyvai.InitializeRoutes());

            listas.Add("pirmas");
            listas.AddRange(new string[] { "antras", "trecias" });

            listas2.Add(1);
            
        }

        public static void AutobusuUzduotis()
        {
            var busRoutes = new List<BusRoute>(Masyvai.InitializeRoutes());

            Console.WriteLine("Pries stoteliu trinima:");

            foreach (var busRoute in busRoutes)
            {
                Console.WriteLine($"Marsrutas {busRoute.Number}, turi {busRoute.BusStops.Count()} stoteliu");
            }

            busRoutes = RemoveBusStopsThatContains(busRoutes, "r");

            Console.WriteLine("Po stoteliu trinima:");

            foreach (var busRoute in busRoutes)
            {
                Console.WriteLine($"Marsrutas {busRoute.Number}, turi {busRoute.BusStops.Count()} stoteliu");
            }

            Console.Write("i kokia stotele norite nuvykti ? ");
            var destination = Console.ReadLine();

            var route = busRoutes.FindBusTo(destination);

            Console.WriteLine(route is null ? $"marsruti i {destination} nera" : $"marsrutas {route.Number} is {route.Origin} per {destination} vyksta i {route.Destination}");
        }

        private static List<BusRoute> RemoveBusStopsThatContains(IEnumerable<BusRoute> busRoutes, string letter)
        {
            foreach (var busRoute in busRoutes)
            {
                busRoute.BusStops = busRoute.BusStops.Where(busStop => !busStop.Contains(letter)).ToArray();
            }

            return busRoutes.ToList();
        }

        public static void AntraAutobusoUzduotis()
        {
            while (true)
            {
                string userType = GetUserType();

                if (userType == "administratorius")
                {
                    AdminstratorMeniu();
                }
                else
                {
                    PassangerSearch();
                }
            }
        }

        private static string GetUserType()
        {
            string userType = null;

            do
            {
                Console.Clear();

                if (userType != null)
                {
                    Console.WriteLine($"{userType} netinka...");
                    Console.WriteLine("Pasirinkite \"Administratorius\" arba \"Keleivis\"\n\n");
                }
                else
                {
                    Console.WriteLine("Sveiki prisijunge i Autobusai.lt Consolini interface");
                    Console.WriteLine("galimi du prisijungimai (Administratorius/Keleivis)");
                }

                Console.Write("Norite prisijungti kaip ? ");
                userType = Console.ReadLine().ToLower();
            }
            while (userType != "administratorius" && userType != "keleivis");

            return userType;
        }

        private static void AdminstratorMeniu()
        {           
            var loggedIn = CheckAdminPasword();
            if (!loggedIn) return;

            while (true)
            {
                var action = ChoseAction();
                if (string.IsNullOrEmpty(action)) return;

                if (action == "add")
                {
                    BusRoutes.Add(CreateBusRoute());
                }
                else if (action == "delete")
                {
                    var route = ChoseRoute("istrinti");
                    if (route is null) return;

                    BusRoutes.Remove(route);
                }
                else if (action == "update")
                {
                    var route = ChoseRoute("atnaujinti");
                    if (route is null) return;

                    UpdateBusRoute(route);
                }

                ShowAllBusRoutes();
                Console.Write("norite iseiti ? rasykite \"quit\", testi spauskite ENTER");
                
                if ("quit" == Console.ReadLine()) 
                { 
                    return; 
                }
            }
        }

        public static BusRoute CreateBusRoute()
        {
            Console.WriteLine("Iveskite naujo Marsruto pavadinima pvz: (A45)");
            Console.Write("Pavadinimas: ");
            var number = Console.ReadLine();

            //Get Lengtht
            int numberOfStops = -1;
            var textNumber = string.Empty;
            do
            {             
                Console.Clear();
                Console.Write("Iveskite stoteliu kieki: ");
                textNumber = Console.ReadLine();
            }
            while(!int.TryParse(textNumber, out numberOfStops));

            var stoteles = new string[numberOfStops];

            for (int i = 0; i < numberOfStops; i++)
            {
                Console.Write($"{i+1}-os stoteles pavadinimas: ");
                stoteles[i] = Console.ReadLine();
            }

            return new BusRoute(number, stoteles);
        }

        public static void UpdateBusRoute(BusRoute route)
        {
            var actionStops = ChoseAction(route);

            if (string.IsNullOrEmpty(actionStops))
            { 
                return; 
            }

            if (actionStops == "add")
            {
                UpdateBusRoutes(BusRoute.AddBusStop(route, GetStopNameToAdd(route, out int? index), index)); 
            }
            else if (actionStops == "delete")
            {
                UpdateBusRoutes(BusRoute.DeleteBusStop(route, GetStopIndex(route, "istrinti")));
            }
            else if (actionStops == "update")
            {
                UpdateBusRoutes(BusRoute.UpdateBusName(route, GetBusStopName(), GetStopIndex(route, "pakeisti")));
            }

            ShowBusStopsOfRoute(route);
            Console.ReadLine();
        }

        public static void UpdateBusRoutes(BusRoute route)
        {
            int index = -1;

            for (int i = 0; i < BusRoutes.Count(); i++)
            {
                if(BusRoutes[i].Number == route.Number)
                {
                    index = i;
                    break;
                }
            }

            BusRoutes[index] = route;
        }

        public static int? GetStopIndex(BusRoute route, string toAction)
        {
            Console.Clear();
            ShowBusStopsOfRoute(route);
            Console.Write($"\nPrasome parasyti stoteles indeksa kuri norite {toAction}:");
            string busStopIndex = Console.ReadLine();

            if (int.TryParse(busStopIndex, out int indexNumber))
            {
                return indexNumber;
            }
            else
            {
                return null;
            }
        }

        public static string GetBusStopName()
        {
            Console.Write("\nPrasome parasyti stoteles pavadinima kuri norite prideti:");
            return Console.ReadLine();
        }

        public static string GetStopNameToAdd(BusRoute route, out int? index)
        {
            Console.Clear();
            ShowBusStopsOfRoute(route);
            var busStop = GetBusStopName();

            Console.WriteLine("jei norite pasirinkti indeksa uz kurio iterpti nauja stotele, " +
                "\nparasykite, ji (skaicius) jei parasysite ne skaiciu arba paspausite ENTER, " +
                "Nauja stotele bus iterpta paciame gale");
            Console.Write("Indeksas: ");
            var indexText = Console.ReadLine();

            if(int.TryParse(indexText, out int indexNumber))
            {
                index = indexNumber;
            }
            else
            {
                index = null;
            }
            
            return busStop;
        }

        public static string ChoseAction(BusRoute route = null)
        {
            var choice = string.Empty;

            do
            {
                Console.Clear();

                if (!string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Noredami iseiti rasykite \"quit\"");
                    Console.WriteLine($"{choice} netinka pasirinkite viena is: Delete, Add, Update");
                }

                if (route is not null)
                {
                    ShowBusStopsOfRoute(route);
                }
                else
                {
                    ShowAllBusRoutes();
                }
                
                Console.WriteLine("Pasirinkite viena is veiksmu, (Delete, Add, Update) \njei norite uzdaryti rasykite \"quit\"");
                Console.Write("Jusu pasirinkimas: ");
                choice = Console.ReadLine().ToLower();

                if (choice == "quit") return string.Empty;
            }
            while (choice != "delete" && choice != "add" && choice != "update");

            return choice;
        }

        public static void ShowBusStopsOfRoute(BusRoute route)
        {
            for(int i = 0; i < route.BusStops.Length; i++)
            {
                Console.WriteLine($"index: [{i}], name: \"{route.BusStops[i]}\"");
            }
        }

        public static void ShowAllBusRoutes()
        {
            Console.WriteLine("Marsrutai: \n");

            foreach (var route in BusRoutes)
            {
                Console.WriteLine($"{route.Number} has {route.BusStops.Length}");
            }

            Console.WriteLine();
        }

        public static BusRoute ChoseRoute(string actionName)
        {
            var choice = string.Empty;

            do
            {
                Console.Clear();

                if (!string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Noredami iseiti rasykite \"quit\"");
                    Console.WriteLine($"{choice} netinka pasirinkite viena is: {BusRoutes.Select(route => route.Number).Aggregate("", (joined , item) => joined + item + ",")} ");
                }

                ShowAllBusRoutes();

                Console.WriteLine($"Pasirinkite marsruta kuri norite {actionName}, jei norite uzdaryti rasykite \"quit\"");
                Console.Write("Jusu pasirinkimas: ");
                choice = Console.ReadLine();

                if (choice == "quit") return null;
            }
            while (!BusRoutes.Any(route => route.Number.ToLower() == choice.ToLower()));

            return BusRoutes.Where(route => route.Number.ToLower() == choice.ToLower()).FirstOrDefault();
        }

        private static bool CheckAdminPasword()
        {
            var passwordCorrect = true;

            while(true)
            {
                Console.Clear();

                if (!passwordCorrect)
                {
                    Console.WriteLine("Noredami iseiti rasykite \"quit\"");
                    Console.WriteLine("Neteisingai bandykite dar kart !");
                }
                
                Console.Write("\nIveskite Slaptazodi: ");
                var pasword = Console.ReadLine();

                if (pasword == "admin") return true;

                if(pasword == "quit")
                {
                    return false;
                }
            }           
        }

        private static void PassangerSearch()
        {
            Console.Clear();
            Console.WriteLine("parasykite i kokia stotele norite nuvykti");
            Console.Write("Stotele: ");
            var busStop = Console.ReadLine();

            var routes = BusRoutes.FindBuses2(busStop);

            if((routes?.Count() ?? 0) == 0)
            {
                Console.WriteLine($"marsrutu i {busStop} nera");
            }

            foreach (var route in routes)
            {
                Console.WriteLine($"marsrutas {route.Number} is {route.Origin} per {busStop} vyksta i {route.Destination}");
            }

            Console.ReadLine();
        }


        public static List<BusRoute> RemoveBusRoute(IEnumerable<BusRoute> busRoutes, string number)
        {
           return busRoutes.Where(route => route.Number != number).ToList();
        }
    }
}
