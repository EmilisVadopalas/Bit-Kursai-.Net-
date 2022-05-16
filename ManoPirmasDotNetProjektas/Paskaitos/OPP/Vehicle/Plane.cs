using ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Plane : Vehicle
    {
        public int WingSpan { get; set; }
        public int NumberOfEngines { get; set; }
        public int MaxAltitude { get; set; }
        public int NumberOfSeats { get; set; }


        public Plane() { }

        public Plane(int numberOfSeats)
        {
            NumberOfSeats = numberOfSeats;
        }


        public override string TimeToTravelDistance(int distance = 100, bool miles = false)
        {
            return $"{distance} {(miles ? "myliu" : "kilometru")} NUSKRISITE per {TimeToTravel(distance, miles)} minuciu";
        }

        public string GetVechicleTypeNormal()
        {
            return "Lektuvas";
        }

        public override string GetVechicleTypeOverriden()
        {
            return "Lektuvas";
        }
    }
}
