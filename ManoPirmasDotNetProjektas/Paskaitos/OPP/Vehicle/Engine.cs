using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Engine
    {
        public FuelType FuelType { get; set; }
        public double Volume { get; set; }
        public double Kilowats { get; set; }

        public double EngineHorsePower
        {
            get 
            { 
                return Kilowats * Car.KilowatsToHorsePower; 
            }
        }

        public Engine() { }
        public Engine(FuelType type, double engineVolume, double engineKilowats)
        {
            FuelType = type;
            Volume = engineVolume;
            Kilowats = engineKilowats;
        }
        public Engine(FuelType type) : this(type, 0, 0) { }       
    }
}
