using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Universitetines
{
    public class Room
    {
        public int Length { get; init; }
        public int Width { get; init; }
        public bool Reserved { get; private set; }

        public Room(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public void Reserve() => 
            Reserved = true;

        public int GetArea() =>
            Length * Width;
    }
}
