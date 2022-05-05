using ManoPirmasDotNetProjektas.Paskaitos.OPP;
using System;
using ManoPirmasDotNetProjektas.Extensions;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle;
using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;

var fordas = new Car("Ford", "Mondeo", new DateTime(2002, 09, 09), 
    FuelType.Gasoline, 2000, 200, "Pilka", BodyType.Sedan, 1800, 220, 800);

var mitsubishi = new Car("Mitsubishi", "SpaceStar", new DateTime(2004, 04, 20), 
    FuelType.Diesel, 1800, 95, "Melyna", 
    BodyType.Hatchback, 1800, 220, 800);

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

var dviratis = new Vehicle
{
    TopSpeed = 50,
    Type = VehicleType.Driving,
    MaxDistance = int.MaxValue,
    Weight = 10,
    Year = new DateTime(2009, 01, 01)
};

var ManoTransportoPriemones = new Vehicle[] { fordas, mitsubishi, kukuruznikas, naikintuvas, dviratis };

Console.WriteLine(ManoTransportoPriemones[0].TimeToTravelDistanceInAnyVechicle());
Console.WriteLine(ManoTransportoPriemones[1].TimeToTravelDistanceInAnyVechicle());
Console.WriteLine(ManoTransportoPriemones[2].TimeToTravelDistanceInAnyVechicle());
Console.WriteLine(ManoTransportoPriemones[3].TimeToTravelDistanceInAnyVechicle());
Console.WriteLine(ManoTransportoPriemones[4].TimeToTravelDistanceInAnyVechicle());

Console.ReadLine();

Console.WriteLine("\n\nNe overridinti paprastai nuo kintamojo:\n");

Console.WriteLine(fordas.GetVechicleTypeNormal());
Console.WriteLine(mitsubishi.GetVechicleTypeNormal());
Console.WriteLine(kukuruznikas.GetVechicleTypeNormal());
Console.WriteLine(naikintuvas.GetVechicleTypeNormal());
Console.WriteLine(dviratis.GetVechicleTypeNormal());

Console.WriteLine("\n\nis listo:\n");

Console.WriteLine(ManoTransportoPriemones[0].GetVechicleTypeNormal());
Console.WriteLine(ManoTransportoPriemones[1].GetVechicleTypeNormal());
Console.WriteLine(ManoTransportoPriemones[2].GetVechicleTypeNormal());
Console.WriteLine(ManoTransportoPriemones[3].GetVechicleTypeNormal());
Console.WriteLine(ManoTransportoPriemones[4].GetVechicleTypeNormal());

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
Console.ReadLine();
Console.ReadLine();
//var fordoVariklis = new Engine(FuelType.Gasoline, 2000, 200);
//var fordasM = new Car("Ford", "Mondeo", new DateTime(2002, 09, 09), fordoVariklis, "Pilka", BodyType.Sedan, 1800);

//Console.WriteLine("pirmas:" + fordas.CountPriceForTrip(350));
//Console.WriteLine("antras:" + fordasM.CountPriceForTrip(350));

//Console.ReadLine();




























var a1 = new Animal(20, 25);

var p1 = new Bird
{
    FlightSpeed = 50,
    WeigthInGrams= 55,
    HeightInCm= 60
};

var p2 = new Bird(60, 65, 70);

Console.WriteLine($"P1 {p1.FlightSpeed} {p1.WeigthInGrams} {p1.HeightInCm}");

Console.WriteLine($"P2 {p2.FlightSpeed} {p2.WeigthInGrams} {p2.HeightInCm}");

Console.WriteLine("\n\n Print BIRD:");

p1.PrintClassName1();
p1.PrintClassName2();
p1.PrintClassName3();
p1.PrintClassName4();
p1.PrintClassName5();

Console.WriteLine("\n\n Print Animal:");

a1.PrintClassName1();
a1.PrintClassName2();
a1.PrintClassName3();
a1.PrintClassName4();

PetOwner.PrintWeightOfAnimal(p1);
PetOwner.PrintWeightOfAnimal(a1);


Console.ReadLine();

var animal = new Animal[] { p1, p2, a1 };

Console.WriteLine("\nPrints From Animal Array with Bird \n");

animal[0].PrintClassName1();
animal[0].PrintClassName2();
animal[0].PrintClassName3();
animal[0].PrintClassName4();
//animal[0].PrintClassName5(); tik Bird turi toki metoda.
((Bird)animal[0]).PrintClassName5(); // po casto as Bird

Console.WriteLine("\nPrints From Animal Array with Animal \n");

animal[2].PrintClassName1();
animal[2].PrintClassName2();
animal[2].PrintClassName3();
animal[2].PrintClassName4();
//animal[0].PrintClassName5(); tik Bird turi toki metoda.
try
{
    ((Bird)animal[2]).PrintClassName5(); // po casto as Bird
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\n Printai \n");

Console.WriteLine(animal[0].ToString());
Console.WriteLine(animal[1].ToString());
Console.WriteLine(animal[2].ToString());

Console.WriteLine(a1.ToString());
Console.WriteLine(p1.ToString());
Console.WriteLine(p2.ToString()); // kas bus jei uzkuomentuosim ToString() override'a bird klaseje ?


var jonas = new PetOwner
{
    Name = "Jonas",
    pet1 = a1,
    pet2 = p2,
};

var petras = new PetOwner { Name = "Petras" };
PetOwner antanas = null;

Console.WriteLine("\n jono gyvuno vardas: ");
try
{
    Console.WriteLine(jonas.pet1.ToString());    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\n petro gyvuno vardas: ");
try
{
    Console.WriteLine(petras.pet1.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\n antano gyvuno vardas: ");
try
{
    Console.WriteLine(antanas.pet1.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


Console.WriteLine("\n\n su null checkais... \n");

Console.WriteLine(jonas?.pet1?.ToString() ?? "neturi");
Console.WriteLine(petras?.pet1?.ToString() ?? "neturi");
Console.WriteLine(antanas?.pet1?.ToString() ?? "neturi");



