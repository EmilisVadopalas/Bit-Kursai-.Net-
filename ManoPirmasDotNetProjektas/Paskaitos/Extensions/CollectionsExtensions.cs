using ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Extensions
{
    public static class CollectionsExtensions
    {
        public static BusRoute FindBusTo1(this BusRoute[] busRoutes, string location)
        {
            foreach (var busRoute in busRoutes)
            {
                if (busRoute.Origin == location || busRoute.Destination == location)
                {
                    return busRoute;
                }
            }

            return null;
        }

        public static BusRoute FindBusTo2(this BusRoute[] busRoutes, string location)
        {
            return busRoutes.Where(busRoute => busRoute.Origin == location || busRoute.Destination == location).FirstOrDefault();
        }

        public static BusRoute FindBusTo(this IEnumerable<BusRoute> busRoutes, string location)
        {
            return busRoutes.Where(busRoute => busRoute.Route.Any(busStop => busStop == location)).FirstOrDefault();
        }

        public static BusRoute FindBusTo3(this BusRoute[] busRoutes, string location)
        {
            return Array.Find(busRoutes, busRoute => busRoute.Origin == location || busRoute.Destination == location);
        }

        public static BusRoute[] FindBuses1(this BusRoute[] busRoutes, string location)
        {
            return Array.FindAll(busRoutes, busRoute => busRoute.Origin == location || busRoute.Destination == location);
        }

        public static BusRoute[] FindBuses2(this BusRoute[] busRoutes, string location)
        {
            return busRoutes.Where(busRoute => busRoute.Origin == location || busRoute.Destination == location).ToArray();
        }
    }
}
