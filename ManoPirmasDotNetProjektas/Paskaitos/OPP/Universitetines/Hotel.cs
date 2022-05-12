using System.Linq;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Universitetines
{
    public class Hotel
    {
        private Room[] Rooms { get; init; }

        public Hotel(Room[] rooms)
        {
            Rooms = rooms;
        }

        public int VacantRoomCount() =>
            Rooms.Count(room => room.Reserved = false);

        public Room ReserveRoom(int minArea)
        {
            var filteredRooms = Rooms.Where(room => room.GetArea() > minArea).ToArray();

            if (filteredRooms.Any())
            {
                var min = filteredRooms.Min(room => room.GetArea());

                return filteredRooms.Where(room => room.GetArea() == min).First();
            }

            return null;
        }
    }
}
