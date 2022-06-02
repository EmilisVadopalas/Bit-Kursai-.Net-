using System.Text;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus
{
    public class BusRoute 
    {
        public string Number { get; init; }
        public string Origin => BusStops[0];
        public string Destination => BusStops[^1];
        public string[] BusStops { get; set; }

        public BusRoute(string busNumber, string[] busStops) 
        {
            BusStops = busStops;
            Number = busNumber;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder($"\nMarsrutas {Number}\n");

            for(int i = 0; i < BusStops.Length; i++)
            {
                strBuilder.Append($"\n{i+1}-oji stotele \"{BusStops[i]}\"");
            }

            return strBuilder.ToString();                
        }

        public static BusRoute AddBusStop(BusRoute route, string NewStop, int? index)
        {
            index = ValideIndex(route, index);

            var newBusStops = new string[route.BusStops.Length+1];
            bool stopAdded = false;

            for(int i = 0; i <= newBusStops.Length; i++)
            {
                if (i == index)
                {
                    newBusStops[i] = NewStop;
                    stopAdded = true;
                }
                else
                {
                    newBusStops[i] = route.BusStops[i+(stopAdded ? 1 : 0)];
                }
            }

            route.BusStops = newBusStops;
            return route;
        }

        public static BusRoute DeleteBusStop(BusRoute route, int? index)
        {
            index = ValideIndex(route, index, true);

            var newBusStops = new string[route.BusStops.Length-1];
            bool stopDeleted = false;

            for (int i = 0; i < route.BusStops.Length; i++)
            {
                if (i == index)
                {
                    stopDeleted = true;
                }
                else
                {
                    newBusStops[i - (stopDeleted ? 1 : 0)] = route.BusStops[i];
                }
            }

            route.BusStops = newBusStops;
            return route;
        }

        public static BusRoute UpdateBusName(BusRoute route, string nameOfNewStop, int? index)
        {
            index = ValideIndex(route, index, true);

            for (int i = 0; i < route.BusStops.Length; i++)
            {
                if (i == index)
                {
                    route.BusStops[i] = nameOfNewStop;
                }
            }

            return route;
        }

        private static int ValideIndex(BusRoute route, int? index, bool delete = false)
        {
            index = index is null || index >= route.BusStops.Length ? (delete ? route.BusStops.Length-1 : route.BusStops.Length) : index;
            index = index < 0 ? 0 : index;

            return (int)index;
        }
    }
}
