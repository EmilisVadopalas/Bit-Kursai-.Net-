using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Car
    {
        public const double MilesToKilometers = 1.609344;
        public const double KilowatsToHorsePower = 1.34102209;

        private static int engineVolumeRatioBase = 20;
        private static int weightBase = 1500;
        private static double gasMultiplier = 1.6;

        private static double priceOfDiesel = 1.730;
        private static double priceOfGasoline = 1.690;
        private static double priceOfGas = 0.710;

        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public Engine Engine { get; set; }
        public string Color { get; set; }
        public string BodyType { get; set; }        
        public double Weight { get; set; }

        public Car() { }
        public Car(string make, string model, DateTime year, Engine engine, string color, string body, double weight) 
        {
            Make = make;
            Model = model;  
            Year = year;
            Engine = engine;
            Color = color;
            BodyType = body;
            Weight = weight;
        }
        public Car(string make, string model, DateTime year, string fuelType, 
            double engineVolume, double enginePower, string color, string body, double weight)
        {
            Make = make;
            Model = model;
            Year=year;
            Engine = new Engine(fuelType, engineVolume, enginePower);
            Color = color;
            BodyType = body;
            Weight = weight;
        }
        public Car(string make, string model, DateTime year) 
            : this(make, model, year, null, string.Empty, string.Empty, 0) { }


        public double CountPriceForTrip(int distance = 100, bool miles = false)
        {
            if(Engine.FuelType == "Diesel")
            {
                return GetCarsFuelConsumption(distance, miles) * priceOfDiesel;
            }
            if (Engine.FuelType == "Gas")
            {
                return GetCarsFuelConsumption(distance, miles) * priceOfGas;
            }

            return GetCarsFuelConsumption(distance, miles) * priceOfGasoline;            
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

            if(Engine.FuelType.ToLower() == "gas")
            {
                return (kilometers / ratio) * gasMultiplier;
            }

            return kilometers / ratio;
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

    }
}
