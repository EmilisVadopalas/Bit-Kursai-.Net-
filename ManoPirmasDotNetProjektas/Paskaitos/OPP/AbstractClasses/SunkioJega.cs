using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.AbstractClasses
{
    public abstract class SunkioJega
    {
        public virtual double Pagreitis { protected get; init; } = 0;

        public double GetGravitationalForceOnPerson(double massOfPerson)
        {
            return massOfPerson * Pagreitis;
        }
    }

    public class Planet : SunkioJega
    {
        public override double Pagreitis { protected get; init; }

        public Planet(AccelarationForceForPlanets pagreitis)
        {
            Pagreitis = (double)(int)pagreitis/1000;
        }
    }

    public enum AccelarationForceForPlanets
    {
        Earth = 9822,
        Moon = 1625,
        Mars = 3690,
        Venus = 8870,
        Mercury = 3700,
        Uranus = 8690
    }

    public class Moon : SunkioJega
    {
        public override double Pagreitis { protected get; init; } = 1.625;
    }
    public class Earth : SunkioJega
    {
        public override double Pagreitis { protected get; init; } = 9.822;
    }
    public class Mars : SunkioJega
    {
        public override double Pagreitis { protected get; init; } = 3.69;
    }
    public class Venus : SunkioJega
    {
        public override double Pagreitis { protected get; init; } = 8.87;
    }
    public class Mercury : SunkioJega
    {
        public override double Pagreitis { protected get; init; } = 3.70;
    }
    public class Uranus : SunkioJega
    {
        public override double Pagreitis { protected get; init; } = 8.69;
    }
}
