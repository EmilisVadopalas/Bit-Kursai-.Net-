namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Engine
    {
        public string FuelType { get; set; }
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
        public Engine(string fuelType, double engineVolume, double engineKilowats)
        {
            FuelType = fuelType;
            Volume = engineVolume;
            Kilowats = engineKilowats;
        }
        public Engine(string fuelType) : this(fuelType, 0, 0) { }       
    }
}
