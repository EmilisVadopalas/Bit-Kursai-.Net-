using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP
{
    public class Animal
    {
        public int HeightInCm { get; set; }
        public int WeigthInGrams { get; set; }

        public Animal() { }

        public Animal (int height, int weigth)
        {
            HeightInCm = height;
            WeigthInGrams = weigth;
        }

        public void PrintClassName1()
        {
            Console.WriteLine("Animal");
        }

        public void PrintClassName2()
        {
            Console.WriteLine("Animal");
        }

        public virtual void PrintClassName3()
        {
            Console.WriteLine("Animal");
        }

        public virtual void PrintClassName4()
        {
            Console.WriteLine("Animal");
        }

        public override string ToString()
        {
            return "Animalas";
        }
    }

    public class PetOwner : INameHaver
    {
        public string Name { get; set; }
        public Animal pet1 { get; set; }
        public Bird pet2 { get; set; }

    }

    public class Bird : Animal
    {
        public int FlightSpeed { get; set; }

        public Bird() { }

        public Bird(int speed, int height, int weigth)
            : base(height, weigth)
        {
            FlightSpeed = speed;
        }

        public void PrintClassName1()
        {
            Console.WriteLine("Bird");
        }

        new public void PrintClassName2()
        {
            Console.WriteLine("Bird");
        }

        public void PrintClassName5()
        {
            Console.WriteLine("Bird");
        }

        public override void PrintClassName4()
        {
            Console.WriteLine("Bird");
        }

        public override string ToString()
        {
            return "Paukstis";
        }
    }

    public interface INameHaver
    {
        string Name { get; set; }
    }
}
