using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus
{
    public class BusRoute
    {
        public string Number { get; init; }
        public string Origin => Route[0];
        public string Destination => Route[^1];
        public string[] Route { get; init; }

        public BusRoute(string busNumber, string[] busStops)
        {
            Route = busStops;
            Number = busNumber;
        }
    }
}
