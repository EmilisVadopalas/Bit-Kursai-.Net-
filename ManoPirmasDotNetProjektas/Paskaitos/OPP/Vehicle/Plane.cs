namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle
{
    public class Plane : Vehicle
    {
        public int WingSpan { get; set; }
        public int NumberOfEngines { get; set; }
        public int MaxAltitude { get; set; }
        public int NumberOfSeats { get; set; }

        public override string TimeToTravelDistance(int distance = 100, bool miles = false)
        {
            return $"{distance} {(miles ? "myliu" : "kilometru")} NUSKRISITE per {TimeToTravel(distance, miles)} minuciu";
        }
    }
}
