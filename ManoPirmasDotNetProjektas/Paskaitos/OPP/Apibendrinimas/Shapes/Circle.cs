using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas.Shapes
{
    public class Circle : Shape
    {
        public const double PI = 3.1415926535897931;
        
        private double _radius;

        public double Radius 
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
                Diameter = 2 * value;
                Perimeter = PI * value * 2;
                Area = PI * value * value;
            } 
        }
        public double Diameter { get; private set; }
        public override double Perimeter { get; protected set; }
        public override double Area { get; protected set; }


        public Circle(double radius)
        {
            Radius = radius;
            Diameter = 2 * Radius;
            Perimeter = PI * Radius * 2;
            Area = PI * Radius * Radius;
        }


        public override int CulculateHowManyShapesFit(Rectangle Area)
        {
            var timesFitsInX = Convert.ToInt32(Area.Lenght / Diameter);
            var timesFitsInY = Convert.ToInt32(Area.Height / Diameter);

            return timesFitsInX * timesFitsInY;
        }

        public override string ToString()
        {
            return $"\nradius={Radius}" +
                $"\ndiameter={Diameter}" +
                $"\nCircuference={Perimeter}" +
                $"\nArea={Area}";
        }
    }
}
