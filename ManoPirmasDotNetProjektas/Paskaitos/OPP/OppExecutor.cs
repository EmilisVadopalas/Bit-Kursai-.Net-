using ManoPirmasDotNetProjektas.Extensions;
using ManoPirmasDotNetProjektas.Paskaitos.Helpers.Coverters;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Apibendrinimas.Shapes;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Structs;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.EmployeeNameSpace;
using System;
using System.Linq;
using ManoPirmasDotNetProjektas.Paskaitos.Helpers.ConsolePaints;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Interfaceses.Tasks;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.AbstractClasses;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP
{
    internal static class OppExecutor
    {
        public static void Run()
        {
            //InheratanceTasks();
            //ConclusionTasks();
            //EnumTasks();
            //StructTasks();
            //ArrayTasks();
            //EqualityTasks();
            //EmployeeList();
            //Interfaces();
            PlanetTasks();

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

            var sortedCars = cars.OrderBy(car => car.BodyType.ToString()).ToArray();
            Console.WriteLine("\nSorted linq Built in alphabetical:");
            Car.PrintCarArrayBodies(sortedCars);

            sortedCars = cars.OrderBy(car => (int)car.BodyType).ToArray();
            Console.WriteLine("\nSorted linq Built in numeric:");
            Car.PrintCarArrayBodies(sortedCars);

            //2. Mesurement Converteris
            Console.WriteLine($"100 miles is {Mesuraments.ConvertMeasurements(100, LenghtMesuraments.Mile, LenghtMesuraments.Kilometer)} kilometers");
            Console.WriteLine($"48 Kilometers is {Mesuraments.ConvertMeasurements(48, LenghtMesuraments.Kilometer, LenghtMesuraments.Foot)} Feets");
        }

        private static void StructTasks()
        {
            var me = new PersonStructure
            {
                Name = new PersonNameStructure { FirsName = "Emilis", MiddleName = null, LastName = "Vadopalas" },
                BirthDate = new DateOnly(1995, 09, 20),
                Sex = Sex.male
            };

            var me2 = new PersonStructure(
                new PersonNameStructure { FirsName = "Emilis", MiddleName = new string[] { "Jonas", "Petras" }, LastName = "Vadopalas" },
                new DateOnly(1995, 09, 20),
                Sex.male);

            Console.WriteLine(me);
            Console.WriteLine();
            Console.WriteLine(me2);
        }

        private static void ArrayTasks()
        {
            int[] zodziai = new int[] { 1, 2, 3 };

            if (zodziai.Contains(1))
            {
                Console.WriteLine("yra zodis \"vienas\"");
            }

            if (zodziai.Contains(2))
            {
                Console.WriteLine("yra zodis \"du\"");
            }

            if (zodziai.Contains(4))
            {
                Console.WriteLine("yra zodis \"keturi\"");
            }
        }

        private static void EqualityTasks()
        {
            var person1 = new Person("Emilis1", "Vadopalas", true, new DateTime(1995, 09, 20));
            var person2 = new Person("Emilis2", "Vadopalas", true, new DateTime(1995, 09, 20));
            var person3 = new Person("Emilis3", "Vadopalas", true, new DateTime(1995, 09, 20));
            var person4 = new Person("Emilis4", "Vadopalas", true, new DateTime(1995, 09, 20));
            var person5 = new Person("Emilis5", "Vadopalas", true, new DateTime(1995, 09, 20));
            var person6 = new Person("Emilis5", "Vadopalas", true, new DateTime(1995, 09, 20));

            Console.WriteLine(Person.Contains(new Person[] {person1, person2 , person3, person4, person5}, person5));
            Console.WriteLine(Person.Contains(new Person[] { person1, person2, person3, person4, person5}, person6));

            if (person5 == person6)
            {
                Console.WriteLine("lygus");
            }
            else
            {
                Console.WriteLine("nelygus");
            }

        }

        private static void EmployeeList()
        {
            string n = string.Empty;
            int number = 0;

            do
            {
                Console.Write("iveskite darbuotoju kieki: ");
                n = Console.ReadLine();
                Console.Clear();
            }
            while (!int.TryParse(n, out number));

            var employees = new Employee[number];

            for (int i = 0; i < number; i++)
            {
                Console.Clear();
                Console.WriteLine($"Iveskite {i + 1}-taji darbuotoja:\n");
                employees[i] = Employee.GetEmployeeFromConsoleInput();
            }

            while (true)
            {
                string choice = string.Empty;

                do
                {
                    Console.Clear();
                    Table.PrintLine(50);
                    Table.PrintRow(50, "Meniu");
                    Table.PrintLine(50);
                    Table.PrintRow(50, "Choise", "value");
                    Table.PrintLine(50);
                    Table.PrintRow(50, "Print array as it is", "print");
                    Table.PrintRow(50, "Print filter array", "filter");
                    Table.PrintRow(50, "Print Ordered array", "order");
                    Table.PrintRow(50, "To quit", "quit");
                    Table.PrintLine(50);
                    Console.Write("\nYour meniu choice ?  ");
                    choice = Console.ReadLine();

                    if(choice == "quit")
                    {
                        return;
                    }
                }
                while (choice != "print" && choice != "filter" && choice != "order");

                var EmployeeList = employees;

                if (choice == "filter")
                {
                    do
                    {
                        Console.Clear();
                        Table.PrintLine(100);
                        Table.PrintRow(100, "Meniu");
                        Table.PrintLine(100);
                        Table.PrintRow(100, "Options", "value");
                        Table.PrintLine(100);
                        Table.PrintRow(100, "Filter values", "name, surname, birthdate, salary");
                        Table.PrintRow(100, "Filters operators", "=, >, <, !=, >=, <=");
                        Table.PrintRow(100, "To quit", "quit");
                        Table.PrintLine(100);
                        Console.Write("\nExample: name = Jonas");
                        Console.Write("\nFormat: {filter value} {operator} {value}");
                        Console.Write("\nEnter Filter: ");
                        choice = Console.ReadLine();

                        if (choice == "quit")
                        {
                            return;
                        }
                    }
                    while (!FilterFormatCorrect(choice));

                    var splited = choice.Trim().Split(" ");                   

                    if (splited[0] == "name")
                    {
                        if (splited[1] == "=")
                        {
                            EmployeeList = employees.Where(employee => employee.Name == splited[2]).ToArray();
                        }
                        else if (splited[1] == "!=")
                        {
                            EmployeeList = employees.Where(employee => employee.Name != splited[2]).ToArray();
                        }
                    }
                    if (splited[0] == "surname")
                    {
                        if (splited[1] == "=")
                        {
                            EmployeeList = employees.Where(employee => employee.Surname == splited[2]).ToArray();
                        }
                        else if (splited[1] == "!=")
                        {
                            EmployeeList = employees.Where(employee => employee.Surname != splited[2]).ToArray();
                        }
                    }
                    if (splited[0] == "birthdate")
                    {                       
                        if (splited[1] == "=")
                        {
                            EmployeeList = employees.Where(employee => employee.BirthDate == DateOnly.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == "!=")
                        {
                            EmployeeList = employees.Where(employee => employee.BirthDate != DateOnly.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == ">")
                        {
                            EmployeeList = employees.Where(employee => employee.BirthDate > DateOnly.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == ">=")
                        {
                            EmployeeList = employees.Where(employee => employee.BirthDate >= DateOnly.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == "<")
                        {
                            EmployeeList = employees.Where(employee => employee.BirthDate < DateOnly.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == "<=")
                        {
                            EmployeeList = employees.Where(employee => employee.BirthDate <= DateOnly.Parse(splited[2])).ToArray();
                        }
                    }
                    if (splited[0] == "salary")
                    {
                        if (splited[1] == "=")
                        {
                            EmployeeList = employees.Where(employee => employee.Salary == int.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == "!=")
                        {
                            EmployeeList = employees.Where(employee => employee.Salary != int.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == ">")
                        {
                            EmployeeList = employees.Where(employee => employee.Salary > int.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == ">=")
                        {
                            EmployeeList = employees.Where(employee => employee.Salary >= int.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == "<")
                        {
                            EmployeeList = employees.Where(employee => employee.Salary < int.Parse(splited[2])).ToArray();
                        }
                        else if (splited[1] == "<=")
                        {
                            EmployeeList = employees.Where(employee => employee.Salary <= int.Parse(splited[2])).ToArray();
                        }
                    }    
                }
                else if (choice == "order")
                {
                    do
                    {
                        Console.Clear();
                        Table.PrintLine(50);
                        Table.PrintRow(50, "Meniu");
                        Table.PrintLine(50);
                        Table.PrintRow(50, "Choise", "value");
                        Table.PrintLine(50);
                        Table.PrintRow(50, "Name desending", "name desc");
                        Table.PrintRow(50, "Name asending", "name asc");
                        Table.PrintRow(50, "Surname desending", "surname desc");
                        Table.PrintRow(50, "Surname asending", "surname asc");
                        Table.PrintRow(50, "BirthDate desending", "birthdate desc");
                        Table.PrintRow(50, "BirthDate asending", "birthdate asc");
                        Table.PrintRow(50, "Salary desending", "salary desc");
                        Table.PrintRow(50, "Salary asending", "salary asc");
                        Table.PrintRow(50, "To quit", "quit");
                        Table.PrintLine(50);
                        Console.Write("\nYour meniu choice ?  ");
                        choice = Console.ReadLine();

                        if (choice == "quit")
                        {
                            return;
                        }
                    }
                    while (choice != "name desc" && choice != "name asc" 
                    && choice != "surname desc" && choice != "surname asc"
                    && choice != "birthdate desc" && choice != "birthdate asc"
                    && choice != "salary desc" && choice != "salary asc");

                    if(choice == "name desc")
                    {
                        EmployeeList = employees.OrderByDescending(employee => employee.Name).ToArray();
                    }
                    if(choice == "name asc")
                    {
                        EmployeeList = employees.OrderBy(employee => employee.Name).ToArray();
                    }
                    if (choice == "surname desc")
                    {
                        EmployeeList = employees.OrderByDescending(employee => employee.Surname).ToArray();
                    }
                    if (choice == "surname asc")
                    {
                        EmployeeList = employees.OrderBy(employee => employee.Surname).ToArray();
                    }
                    if (choice == "birthdate desc")
                    {
                        EmployeeList = employees.OrderByDescending(employee => employee.BirthDate).ToArray();
                    }
                    if (choice == "birthdate asc")
                    {
                        EmployeeList = employees.OrderBy(employee => employee.BirthDate).ToArray();
                    }
                    if (choice == "salary desc")
                    {
                        EmployeeList = employees.OrderByDescending(employee => employee.Salary).ToArray();
                    }
                    if (choice == "salary asc")
                    {
                        EmployeeList = employees.OrderBy(employee => employee.Salary).ToArray();
                    }
                }

                EmployeeList.PrintEmployeeTable();
            }
        }

        private static bool FilterFormatCorrect(string filter)
        {
            var splited = filter.Trim().Split(" ");

            //format check
            if(splited.Length != 3)
            {
                return false;
            }

            //filter name check
            if(splited[0] != "name" && splited[0] != "surname" 
                && splited[0] != "birthdate" && splited[0] != "salary")
            {
                return false;
            }

            //operator check
            if (splited[1] != "=" && splited[1] != ">"
                && splited[1] != "<" && splited[1] != "!="
                 && splited[1] != ">=" && splited[1] != "<=")
            {
                return false;
            }

            //type conversion check
            if(splited[0] == "birthdate" && !DateOnly.TryParse(splited[2], out _))
            {
                return false;
            }

            if (splited[0] == "salary" && !int.TryParse(splited[2], out _))
            {
                return false;
            }

            return true;
        }

        private static void Interfaces()
        {
            var save1 = new Ps2SaveData();
            var save2= new Ps2SaveData();
            var save3 = new Ps2SaveData();

            save1.Save();
            //save1.Delete();

            var saves = new ISaveData[] {save1, save2, save3 };

            saves[1].Delete();
            saves[1].Save();

            Flight[] f1 = new Flight[5] 
            {
                new Flight ( "A623", new Plane(4), new Passenger[2] { new Passenger( "Jonas", "Jonaitis" ), new Passenger("Petras", "Jonaitis" ) } ),
                new Flight ( "A254", new Plane(8), new Passenger[1] { new Passenger( "Jonas", "Jonaitis" ) }),
                new Flight ( "A143", new Plane(22), new Passenger[3] { new Passenger( "Jonas", "Jonaitis" ), new Passenger("Petras", "Jonaitis" ), new Passenger("Petras", "Jonaitis") } ),
                new Flight ( "A693", new Plane(48), new Passenger[5] { new Passenger( "Jonas", "Jonaitis" ), new Passenger("Petras", "Jonaitis" ), new Passenger("Petras", "Jonaitis"), new Passenger("Petras", "Jonaitis" ), new Passenger("Petras", "Jonaitis") } ),
                new Flight ( "A453", new Plane(12), new Passenger[4] { new Passenger( "Jonas", "Jonaitis" ), new Passenger("Petras", "Jonaitis" ), new Passenger("Petras", "Jonaitis") , new Passenger("Petras", "Jonaitis" ) } )
            };

            Console.WriteLine("\n\nBefore Sort");
            foreach(var f in f1)
            {
                Console.WriteLine(f);
            }

            Array.Sort(f1);
            Array.Reverse(f1);

            Console.WriteLine("\n\nAfterSort");
            foreach (var f in f1)
            {
                Console.WriteLine(f);
            }

        }

        public static void PlanetTasks()
        {
            var planet = string.Empty;
            var weight = string.Empty;
            double humanMass = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Pasirinkimai: moon, earth, mars, venus, mercury, uranus");
                Console.Write("Pasirinkite planeta: ");
                planet = Console.ReadLine();
            } 
            while (planet != "moon" && planet != "earth" && planet != "mars" && planet != "venus" && planet != "mercury" && planet != "uranus");

            do
            {
                Console.Clear();
                Console.Write("Iveskite svori kilogramais: ");
                weight = Console.ReadLine();
            } 
            while (!double.TryParse(weight, out humanMass));

            Planet planetPlanet = null;
            SunkioJega planetPlanet2 = null;

            if(planet == "moon")
            {
                planetPlanet = new Planet(AccelarationForceForPlanets.Moon);
                planetPlanet2 = new Moon();
            }
            else if (planet == "earth")
            {
                planetPlanet = new Planet(AccelarationForceForPlanets.Earth);
                planetPlanet2 = new Earth();
            }
            else if (planet == "mars")
            {
                planetPlanet = new Planet(AccelarationForceForPlanets.Mars);
                planetPlanet2 = new Mars();
            }
            else if (planet == "venus")
            {
                planetPlanet = new Planet(AccelarationForceForPlanets.Venus);
                planetPlanet2 = new Venus();
            }
            else if (planet == "mercury")
            {
                planetPlanet = new Planet(AccelarationForceForPlanets.Mercury);
                planetPlanet2 = new Mercury();
            }
            else if (planet == "uranus")
            {
                planetPlanet = new Planet(AccelarationForceForPlanets.Uranus);
                planetPlanet2 = new Uranus();
            }

            var gForce1 = planetPlanet.GetGravitationalForceOnPerson(humanMass);
            var diff1 = new Planet(AccelarationForceForPlanets.Earth).GetGravitationalForceOnPerson(humanMass) / gForce1;
            var gForce2 = planetPlanet2.GetGravitationalForceOnPerson(humanMass);
            var diff2 = new Earth().GetGravitationalForceOnPerson(humanMass) / gForce2;

            Console.WriteLine("\nSkaiciuojant su Planet klase:");
            Console.WriteLine($"Jusu Sunkis {planet}'e butu \n{gForce1} niutonu, \n{diff1} x karto zemes sunkio");

            Console.WriteLine($"\n\nSkaiciuojant su {planetPlanet2.GetType().Name} klase:");
            Console.WriteLine($"Jusu Sunkis {planet}'e butu \n{gForce2} niutonu, \n{diff2} x karto zemes sunkio");
        }
    }
}
