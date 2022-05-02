using ManoPirmasDotNetProjektas.Paskaitos.OPP;
using System;
using ManoPirmasDotNetProjektas.Extensions;

var zmogus = new Person("Emilis", "Vadopalas", true);

var zmogus2 = new Person
{
    Name = "Emilis",
    Surname = "Vadopalas",
    DateOfBirth = new DateTime(1995, 09, 20),
    IsMale = true    
};

int skaicius = 1;

Console.WriteLine(skaicius.ToWord());


//Console.WriteLine(zmogus2.Age);
//Console.WriteLine(zmogus.GetFullNameWithInitials());

Console.ReadLine();




























var a1 = new Animal(20, 25);

var p1 = new Bird
{
    FlightSpeed = 50,
    WeigthInGrams= 55,
    HeightInCm= 60
};

var p2 = new Bird(60, 65, 70);

Console.WriteLine($"P1 {p1.FlightSpeed} {p1.WeigthInGrams} {p1.HeightInCm}");

Console.WriteLine($"P2 {p1.FlightSpeed} {p1.WeigthInGrams} {p1.HeightInCm}");

p1.PrintClassName1();
p1.PrintClassName2();
p1.PrintClassName3();
p1.PrintClassName4();
p1.PrintClassName5();

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



