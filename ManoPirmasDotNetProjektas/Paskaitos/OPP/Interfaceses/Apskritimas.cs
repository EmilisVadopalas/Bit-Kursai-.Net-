using System;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses
{
    public class Apskritimas : IFigura, ISkaiciavimas 
    {
       
        public double Radius { get; init; }

        public Apskritimas()
        {
            var stringNumber = string.Empty;
            double radius = 0;

            do
            {
                Console.Clear();
                Console.Write("Iveskite apskritimo r: ");
                stringNumber = Console.ReadLine();
            }
            while (!double.TryParse(stringNumber, out radius));

            Radius = radius;
        }

        public string Pavadinimas() => "Apskritimas";

        public double Perimetras() => 2 * Math.PI * Radius;

        public double Plotas() => Math.PI * Radius * Radius;
    }


}
