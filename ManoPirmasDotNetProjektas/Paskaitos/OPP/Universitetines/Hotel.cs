using System.Collections.Generic;
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
            Rooms.Count(room => room.Reserved == false);

        public Room ReserveRoom(int minArea)
        {
            List<Room> filteredRooms = new List<Room>();
            
            for(int i = 0; i < filteredRooms.Count; i++)
            {
                if (Rooms[i].GetArea() > minArea)
                {
                    filteredRooms.Add(Rooms[i]);
                }
            }        

            filteredRooms = Rooms.Where(room => room.GetArea() > minArea).ToList();

            if (filteredRooms.Any())
            {
                var min = filteredRooms.Min(room => room.GetArea());

                var roomReserved = filteredRooms.Where(room => room.GetArea() == min).First();
                roomReserved.Reserve();

                return roomReserved;
            }

            return null;
        }
    }
}
