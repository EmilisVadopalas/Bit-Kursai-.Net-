using ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses.Tasks
{
    public class Flight : IComparable<Flight>
    {
        private string FlightNo { get; set; }
        private Passenger[] Passengers { get; set; }
        private Plane Plane { get; set; }


        public Flight(string flightNo, Plane plane, Passenger[] passengers)
        {
            FlightNo = flightNo;
            this.Passengers = passengers;
            Plane = plane;
        }

        public override string ToString() =>
            $"{FlightNo} {Passengers.Count()}/{Plane.NumberOfSeats}";

        public int CompareTo(Flight other) =>
            Plane.NumberOfSeats - other.Plane.NumberOfSeats;
    }
}
