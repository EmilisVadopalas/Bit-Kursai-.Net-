using System;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas.Shapes
{
    public class Shape
    {
        public virtual double Area { get; protected set; }
        public virtual double Perimeter { get; protected set; }

        public double CalculateArea() => Area;
        public double CalculatePerimeter() => Perimeter;
        public virtual int CulculateHowManyShapesFit(Rectangle Area) => Convert.ToInt32(Area.Area / this.Area);
        //public static double GetWireNeededForShapesProduction(Shape[] shapes) => shapes.Sum(x => x.Perimeter); using linq
        public static double GetWireNeededForShapesProduction(Shape[] shapes)
        {
            double lengthOfWire = 0;

            foreach (Shape shape in shapes)
            {
                lengthOfWire += shape.Perimeter;
            }

            return lengthOfWire;
        }
    }
}
