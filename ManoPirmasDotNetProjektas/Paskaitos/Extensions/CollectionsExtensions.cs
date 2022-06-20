using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;
using ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return busRoutes.Where(busRoute => busRoute.BusStops.Any(busStop => busStop == location)).FirstOrDefault();
        }

        public static BusRoute FindBusTo3(this BusRoute[] busRoutes, string location)
        {
            return Array.Find(busRoutes, busRoute => busRoute.Origin == location || busRoute.Destination == location);
        }

        public static BusRoute[] FindBuses1(this BusRoute[] busRoutes, string location)
        {
            return Array.FindAll(busRoutes, busRoute => busRoute.Origin == location || busRoute.Destination == location);
        }

        public static BusRoute[] FindBuses2(this IEnumerable<BusRoute> busRoutes, string location)
        {
            return busRoutes.Where(busRoute => busRoute.BusStops.Any(busStop => busStop == location)).ToArray();
        }

        public static IEnumerable<Book> TopLongestBooks(this IEnumerable<Book> books, int quantity)
        {        
            return books.OrderByDescending(x => x.PageCount).Take(quantity);
        }

        public static IEnumerable<TSource> SelectTopBy<TSource, TKey>(this IEnumerable<TSource> objs, Expression<Func<TSource, TKey>> keySelector, int quantity)
        {
            return objs.OrderByDescending(keySelector.Compile()).Take(quantity);
        }
    }
}
