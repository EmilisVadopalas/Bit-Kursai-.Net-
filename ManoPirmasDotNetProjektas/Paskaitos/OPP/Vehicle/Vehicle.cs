using System;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Vehicle
    {
        public double TopSpeed { get; set; }
        public double Weight { get; set; }
        public DateTime Year { get; init; }
        public int MaxDistance { get; set; }
        public VehicleType Type { get; set; }


        public Vehicle() { }

        public Vehicle(double speed, double weight, DateTime year, int distance, VehicleType type)
        {
            TopSpeed = speed;
            Weight = weight;
            Year = year;
            MaxDistance = distance;
            Type = type;
        }
    }
}
