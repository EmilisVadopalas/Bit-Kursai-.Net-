using System;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses
{
    public class Staciakampis : IFigura, ISkaiciavimas
    {
        private double Plotis { get; init; }
        private double Aukstis { get; init; }

        public Staciakampis()
        {
            var stringNumber = string.Empty;
            double aukstis = 0;
            double plotis = 0;

            do
            {
                Console.Clear();
                Console.Write("Iveskite staciakampio auksti: ");
                stringNumber = Console.ReadLine();
            } 
            while (!double.TryParse(stringNumber, out aukstis));

            do
            {
                Console.Clear();
                Console.Write("Iveskite staciakampio ploti: ");
                stringNumber = Console.ReadLine();
            }
            while (!double.TryParse(stringNumber, out plotis));

            Plotis = plotis;
            Aukstis = aukstis;
        }

        public string Pavadinimas() => Plotis == Aukstis ? "Kvadratas" : "Staciakampis";

        public double Perimetras() => (2 * Plotis) + (2 * Aukstis);

        public double Plotas() => Plotis * Aukstis;
    }


}
