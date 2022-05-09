using ManoPirmasDotNetProjektas.Extensions;
using ManoPirmasDotNetProjektas.Paskaitos.Helpers.Coverters;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas.Shapes;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle;
using System;
using System.Linq;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP
{
    internal static class OppExecutor
    {
        public static void Run()
        {
            //InheratanceTasks();
            //ConclusionTasks();
            EnumTasks();

            Console.ReadLine();
        }

        private static void InheratanceTasks()
        {
            var fordas = new Car("Ford", "Mondeo", new DateTime(2002, 09, 09),
                FuelType.Gasoline, 2000, 200, "Pilka", BodyType.Sedan, 1800, 220, 800);

            var mitsubishi = new Car("Mitsubishi", "SpaceStar", new DateTime(2004, 04, 20),
                FuelType.Diesel, 1800, 95, "Melyna",
                BodyType.Hatchback, 1800, 220, 800);

            //Car tusciasAutomobilis = fordas;

            Car tusciasAutomobilis = null;

            tusciasAutomobilis ??= mitsubishi;

            Console.WriteLine(tusciasAutomobilis?.Make);

            Console.ReadLine();

            var kukuruznikas = new Plane
            {
                WingSpan = 100,
                TopSpeed = 400,
                MaxAltitude = 1800,
                NumberOfSeats = 10,
                NumberOfEngines = 3,
                MaxDistance = 500,
                Type = VehicleType.Flying,
                Weight = 5468,
                Year = new DateTime(1987, 5, 6)
            };

            var naikintuvas = new Plane
            {
                WingSpan = 50,
                TopSpeed = 1200,
                MaxAltitude = 3000,
                NumberOfSeats = 2,
                NumberOfEngines = 2,
                MaxDistance = 400,
                Type = VehicleType.Flying,
                Weight = 4566,
                Year = new DateTime(2016, 08, 24)
            };

            var dviratis = new Vehicle.Vehicle
            {
                TopSpeed = 50,
                Type = VehicleType.Driving,
                MaxDistance = int.MaxValue,
                Weight = 10,
                Year = new DateTime(2009, 01, 01)
            };

            var ManoTransportoPriemones = new Vehicle.Vehicle[] { fordas, mitsubishi, kukuruznikas, naikintuvas, dviratis };

            Console.WriteLine(ManoTransportoPriemones[0].TimeToTravelDistanceInAnyVechicle(350));
            Console.WriteLine(ManoTransportoPriemones[1].TimeToTravelDistanceInAnyVechicle(350));
            Console.WriteLine(ManoTransportoPriemones[2].TimeToTravelDistanceInAnyVechicle(350));
            Console.WriteLine(ManoTransportoPriemones[3].TimeToTravelDistanceInAnyVechicle(350));
            Console.WriteLine(ManoTransportoPriemones[4].TimeToTravelDistanceInAnyVechicle(350));

            Console.ReadLine();

            Console.WriteLine("\n\nNe overridinti paprastai nuo kintamojo:\n");

            Console.WriteLine(fordas.GetVechicleTypeNormal());
            Console.WriteLine(mitsubishi.GetVechicleTypeNormal());
            Console.WriteLine(kukuruznikas.GetVechicleTypeNormal());
            Console.WriteLine(naikintuvas.GetVechicleTypeNormal());
            Console.WriteLine(dviratis.GetVechicleTypeNormal());

            Console.WriteLine("\n\nis listo:\n");

            Console.WriteLine(ManoTransportoPriemones[0].GetVechicleTypeNormal()); //fordas
            Console.WriteLine(ManoTransportoPriemones[1].GetVechicleTypeNormal()); //mitsubishi
            Console.WriteLine(ManoTransportoPriemones[2].GetVechicleTypeNormal()); //kukuruznikas
            Console.WriteLine(ManoTransportoPriemones[3].GetVechicleTypeNormal()); //naikinbtucvas
            Console.WriteLine(ManoTransportoPriemones[4].GetVechicleTypeNormal()); //dviratis

            Console.ReadLine();

            Console.WriteLine("\n\nOverridinti paprastai nuo kintamojo:\n");

            Console.WriteLine(fordas.GetVechicleTypeOverriden());
            Console.WriteLine(mitsubishi.GetVechicleTypeOverriden());
            Console.WriteLine(kukuruznikas.GetVechicleTypeOverriden());
            Console.WriteLine(naikintuvas.GetVechicleTypeOverriden());
            Console.WriteLine(dviratis.GetVechicleTypeOverriden());

            Console.WriteLine("\n\nis listo:\n");

            Console.WriteLine(ManoTransportoPriemones[0].GetVechicleTypeOverriden());
            Console.WriteLine(ManoTransportoPriemones[1].GetVechicleTypeOverriden());
            Console.WriteLine(ManoTransportoPriemones[2].GetVechicleTypeOverriden());
            Console.WriteLine(ManoTransportoPriemones[3].GetVechicleTypeOverriden());
            Console.WriteLine(ManoTransportoPriemones[4].GetVechicleTypeOverriden());

            Console.ReadLine();
        }

        private static void ConclusionTasks()
        {
            ///
            /// Pirma
            ///
            Console.WriteLine("1. studentu pazymiu vidurkis:");
            var studentas = new Student(new int[] { 10, 9, 5, 4, 10, 8, 7, 10, 8, 9, 5, 4, 9, 9, 10, 9, 2, 10, 10, 10, 7, 8, 9 });
            Console.WriteLine($"\nStudento vidurkis: {studentas.CalculateGradeAvg()}");



            ///
            /// Antra
            ///
            Console.WriteLine("\n\n2.Person FullName length:");
            var personas = new Person("Emilis", "Vadopalas", true, new DateTime(1995, 09, 20));
            Console.WriteLine($"\nVardas: {personas.Name}" +
                $"\nPavarde: {personas.Surname}" +
                $"\nPilnas vardas: {personas.FullName.GetFullName()}" +
                $"\nPilno vardo ilgis: {personas.FullName.GetFullNameLenght}");



            ///
            /// Trecia
            ///
            Console.WriteLine("\n\n3.Figuros ju plotas, bei kiek figuru tilptu i tam tikra plota");
            var circle1 = new Circle(5);
            var circle2 = new Circle(42);
            var circle3 = new Circle(3.8);

            var rectangle1 = new Rectangle(4, 4);
            var rectangle2 = new Rectangle(4.8, 3.84);
            var rectangle3 = new Rectangle(54, 94);

            var area1 = new Rectangle(54, 54);
            var area2 = new Rectangle(150, 100);
            var area3 = new Rectangle(800, 9);

            Console.WriteLine("\nSusikuriam figuras, bei plotus:");
            Console.WriteLine($"\ncicrcle1:{circle1}");
            Console.WriteLine($"\ncicrcle2:{circle2}");
            Console.WriteLine($"\ncicrcle3:{circle3}");
            Console.WriteLine($"\nrectangle1:{rectangle1}");
            Console.WriteLine($"\nrectangle2:{rectangle2}");
            Console.WriteLine($"\nrectangle3:{rectangle3}");
            Console.WriteLine($"\narea1:{area1}");
            Console.WriteLine($"\narea2:{area2}");
            Console.WriteLine($"\narea3:{area3}");

            Console.WriteLine($"\n\nKiek figuru tilps i pirma plota ({area1.Lenght}x{area1.Height}) ?" +
                $"\n circle1: {circle1.CulculateHowManyShapesFit(area1)} kartu" +
                $"\n circle2: {circle2.CulculateHowManyShapesFit(area1)} kartu" +
                $"\n circle3: {circle3.CulculateHowManyShapesFit(area1)} kartu" +
                $"\n rectangle1: {rectangle1.CulculateHowManyShapesFit(area1)} kartu" +
                $"\n rectangle2: {rectangle2.CulculateHowManyShapesFit(area1)} kartu" +
                $"\n rectangle3: {rectangle3.CulculateHowManyShapesFit(area1)} kartu");

            Console.WriteLine($"\n\nKiek figuru tilps i antra plota ({area2.Lenght}x{area2.Height}) ?" +
               $"\n circle1: {circle1.CulculateHowManyShapesFit(area2)} kartu" +
               $"\n circle2: {circle2.CulculateHowManyShapesFit(area2)} kartu" +
               $"\n circle3: {circle3.CulculateHowManyShapesFit(area2)} kartu" +
               $"\n rectangle1: {rectangle1.CulculateHowManyShapesFit(area2)} kartu" +
               $"\n rectangle2: {rectangle2.CulculateHowManyShapesFit(area2)} kartu" +
               $"\n rectangle3: {rectangle3.CulculateHowManyShapesFit(area2)} kartu");

            Console.WriteLine($"\n\nKiek figuru tilps i trecia plota ({area3.Lenght}x{area3.Height}) ?" +
               $"\n circle1: {circle1.CulculateHowManyShapesFit(area3)} kartu" +
               $"\n circle2: {circle2.CulculateHowManyShapesFit(area3)} kartu" +
               $"\n circle3: {circle3.CulculateHowManyShapesFit(area3)} kartu" +
               $"\n rectangle1: {rectangle1.CulculateHowManyShapesFit(area3)} kartu" +
               $"\n rectangle2: {rectangle2.CulculateHowManyShapesFit(area3)} kartu" +
               $"\n rectangle3: {rectangle3.CulculateHowManyShapesFit(area3)} kartu");




            ///
            /// Ketvirta
            ///
            Console.WriteLine("\n\n4.Sudeti figuras i masyva ir apskaiciuoti kiek laido reiktu, jom islankstyti");
            var shapes = new Shape[] { circle1, circle2, circle3, rectangle1, rectangle2, rectangle3 };
            Console.WriteLine("\nsioms figuroms (circle1, circle2, circle3, rectangle1, rectangle2, rectangle3) sulankstyti prireiktu:" +
                $"\n{Shape.GetWireNeededForShapesProduction(shapes)} mat. vienetu laido..");
        }

        private static void EnumTasks()
        {
            //1. susikurti automobiliu su skirtingais bodytype'ais ir juos isrikiuoti pagal body type'a
            var cars = new Car[]
            {
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Sedan, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Convertible, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.StationWagon, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Hatchback, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Sedan, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.StationWagon, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.SUV, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Sports, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Coupe, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Sedan, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.Hatchback, 1, 1, 1),
                new Car("A", "b", new DateTime(1888, 1, 1), new Engine(), "red", BodyType.MiniVan, 1, 1, 1)
            };


            Console.WriteLine("\nUnsorted:");
            Car.PrintCarArrayBodies(cars);

            var sortedCars = cars.OrderBy(x => x.BodyType.ToString()).ToArray();
            Console.WriteLine("\nSorted linq Built in alphabetical:");
            Car.PrintCarArrayBodies(sortedCars);

            sortedCars = cars.OrderBy(x => (int)x.BodyType).ToArray();
            Console.WriteLine("\nSorted linq Built in numeric:");


            //2. Mesurement Converteris
            Console.WriteLine($"100 miles is {Mesuraments.ConvertMeasurements(100, LenghtMesuraments.Mile, LenghtMesuraments.Kilometer)} kilometers");
            Console.WriteLine($"48 Kilometers is {Mesuraments.ConvertMeasurements(48, LenghtMesuraments.Kilometer, LenghtMesuraments.Foot)} Feets");

        }
    }
}
