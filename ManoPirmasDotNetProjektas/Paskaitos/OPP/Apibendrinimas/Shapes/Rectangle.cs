using System;
using System.Linq;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas.Shapes
{
    public class Rectangle : Shape
    {
        private double _lenght;
        private double _height;

        public double Lenght 
        { 
            get 
            { 
                return _lenght; 
            } 
            set 
            {
                _lenght = value;
                Perimeter = 2 * _lenght + 2 * Height;
                Area = _lenght * Height;
            } 
        }
        public double Height 
        { 
            get 
            { 
                return _height; 
            } 
            set 
            {
                _height = value;
                Perimeter = 2 * Lenght + 2 * _height;
                Area = Lenght * _height;
            } 
        }
        public override double Perimeter { get; protected set; }
        public override double Area { get; protected set; }


        public Rectangle(double lenght, double height)
        {
            Lenght = lenght;
            Height = height;
        }


        public override int CulculateHowManyShapesFit(Rectangle Area)
        {
            var timesFitsInX = Convert.ToInt32(Area.Lenght / Lenght);
            var timesFitsInY = Convert.ToInt32(Area.Height / Height);

            return timesFitsInX * timesFitsInY;
        }

        public override string ToString()
        {
            return $"\nLenght={Lenght}" +
                $"\nHeight={Height}" +
                $"\nPerimeter={Perimeter}" +
                $"\nArea={Area}";
        }
    }
}
