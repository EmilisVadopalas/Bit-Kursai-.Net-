using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Car : Vehicle
    {
        public const double MilesToKilometers = 1.609344;
        public const double KilowatsToHorsePower = 1.34102209;

        private static int engineVolumeRatioBase = 20;
        private static int weightBase = 1500;
        private static double gasMultiplier = 1.6;

        private static double priceOfDiesel = 1.730;
        private static double priceOfGasoline = 1.690;
        private static double priceOfGas = 0.710;


        public string Make { get; init; }
        public string Model { get; init; }
        public Engine Engine { get; set; }
        public string Color { get; set; }
        public BodyType BodyType { get; set; }   


        public Car() { }

        public Car(string make, string model, DateTime year, Engine engine, string color, BodyType body, double weight, double speed, int distance) 
            :base(speed, weight, year, distance, VehicleType.Driving)
        {
            Make = make;
            Model = model;
            Engine = engine;
            Color = color;
            BodyType = body;
        }

        public Car(string make, string model, DateTime year, FuelType fuelType, double engineVolume, double enginePower, string color, BodyType body, double weight, double speed, int distance)
            : this(make, model, year, new(fuelType, engineVolume, enginePower), color, body, weight, speed, distance) { }        

        public Car(string make, string model, DateTime year)
            : this(make, model, year, null, string.Empty, BodyType.Sedan, 0, 100, 500) { }


        /// <summary>
        /// Gets estimated price for travel
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="miles">true - distance in miles false - distance in kilometers</param>
        /// <returns></returns>
        public double CountPriceForTrip(int distance = 100, bool miles = false)
        {
            if(Engine.FuelType == FuelType.Diesel)
            {
                return GetCarsFuelConsumption(distance, miles) * priceOfDiesel;
            }
            if (Engine.FuelType == FuelType.Gas)
            {
                return GetCarsFuelConsumption(distance, miles) * priceOfGas;
            }
            if(Engine.FuelType == FuelType.Gasoline)
            {
                return GetCarsFuelConsumption(distance, miles) * priceOfGasoline;
            }

            return 0;                        
        }

        public override string ToString()
        {
            return $"CAR: {Make} {Model} {Year.ToString("yyyy-MM-dd")} {Color} {BodyType} {Weight} ";
        }

        public double GetCarsFuelConsumption(int kilometers = 100, bool miles = false)
        {
            if (Engine == null || Engine.Kilowats == 0 || Engine.Volume == 0)
            {
                return 0;
            }            

            var ratio = (EngineVolumeRatioCalculator() + engineVolumeRatioBase) 
                * (engineVolumeRatioBase / 5) / Engine.Kilowats * (weightBase/Weight);

            if (miles)
            {
                kilometers = (int)Math.Round(kilometers * MilesToKilometers);
            }

            if(Engine.FuelType == FuelType.Gas)
            {
                return ((kilometers / ratio) * gasMultiplier) / 15;
            }

            return (kilometers / ratio) / 15;
        }

        private int EngineVolumeRatioCalculator()
        {
            if (Engine.Volume >= 1700 && Engine.Volume <= 1900)
            {
                return 10;
            }
            else if (Engine.Volume >= 1500 && Engine.Volume <= 2100)
            {
                return 9;
            }
            else if (Engine.Volume >= 1400 && Engine.Volume <= 2300)
            {
                return 8;
            }
            else if (Engine.Volume >= 1200 && Engine.Volume <= 2400)
            {
                return 7;
            }
            else if (Engine.Volume <= 2600)
            {
                return 6;
            }
            else if (Engine.Volume <= 2800)
            {
                return 6;
            }
            else if (Engine.Volume <= 3000)
            {
                return 5;
            }
            else if (Engine.Volume <= 3200)
            {
                return 4;
            }
            else if (Engine.Volume <= 3500)
            {
                return 3;
            }
            else if (Engine.Volume <= 3800)
            {
                return 2;
            }
            else 
            {
                return 1;
            }
        }

        public override string TimeToTravelDistance(int distance = 100, bool miles = false)
        {
            return $"{distance} {(miles ? "myliu" : "kilometru")} NUVAZIUOSITE per {TimeToTravel(distance, miles)} minuciu";
        }

    }
}
