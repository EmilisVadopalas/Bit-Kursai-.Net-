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


        public int GetVehicleAge()
        {
            var now = DateTime.Now;
            var yearDiff = now.Year - Year.Year;

            if(now.Month > Year.Month || (now.Month == Year.Month && now.Day > Year.Day))
            {
                return --yearDiff;
            }
            
            return yearDiff;
        }

        protected int TimeToTravel(int distance = 100, bool miles = false)
        {
            distance = miles 
                ? (int)Math.Round(distance * Car.MilesToKilometers) 
                : distance;

            return (int)Math.Round(60 * (distance / TopSpeed));
        }

        public virtual string TimeToTravelDistance(int distance = 100, bool miles = false)
        {
            return $"{distance} {(miles ? "myliu" : "kilometru")} NUKELIAUSITE per {TimeToTravel(distance, miles)} minuciu";
        }

        public string TimeToTravelDistanceInAnyVechicle(int distance = 100, bool miles = false)
        {
            if(this.GetType() == typeof(Plane))
            {
                return ((Plane)this).TimeToTravelDistance(distance, miles);
            }

            if (this.GetType() == typeof(Car))
            {
                return ((Car)this).TimeToTravelDistance(distance, miles);
            }

            return TimeToTravelDistance(distance, miles);
        }

        public string GetVechicleTypeNormal()
        {
            return "Transporto Priemone";
        }

        public virtual string GetVechicleTypeOverriden()
        {
            return "Transporto Priemone";
        }
    }
}
