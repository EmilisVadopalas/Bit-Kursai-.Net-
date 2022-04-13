// 1 uzduotis: deklaruoti ir inicijuoti kintamuosius.
// kintamieji:
// myFirstString (string)
// myFirstInt (int)
// myFirstBool (bool)
// myFirstDouble (double)
// myFirstDecimal (decimal)
// myFirstFloat (float)

var myFirstString = "mano pirmasis tekstas C# kalboje !";

var myFirstInt = 3;

var myFirstBool = true;

double myFirstDouble = 3.0; // C# default skaicius su kableliu yra double

decimal myFirstDecimal = (decimal)3.0; //kad skaiciu su kableliu paverstume
//i decimal reikia ji castinti i decimal t.y. (decimal)xxx.xxxxx;

decimal mySecondDecimal = 3.0m; //arba skaiciaus gale parasyti m raide, nurodant
// kad tai yra decimal tipo skaicius

float myFirstFloat = (float)3.0; //tapati sutuaci kaip su decimal tik su float'u
// castinam i float 

float mySecondFloat = 3.0f; //apsirasome kad tai yra float.

// 2 uzduotis: sukurti string tipo kintamaji (naudoti var raktazodi) kurio reiksme '5000',
// ta kintamaji konvertuoti i int tipa ir priskirti myFirstInt kintamajui

var penkiTukstanciai = "5000";
myFirstInt = int.Parse(penkiTukstanciai);

// 3 uzduotis: priskirti stringa su reiksme "6000" myFirstInt kintamajam
// naudojant tryParse

if (int.TryParse("6000", out myFirstInt)) //galima ties out parametru tiesiai priskirti kintamaji
{
    System.Console.WriteLine(myFirstInt);
}

if (int.TryParse("7000", out int parsedInt)) //galima out parametre susikurti kintamaji ir ji panaudoti poto
{
    myFirstInt = parsedInt;
    System.Console.WriteLine(myFirstInt);
}

var blogasStringasKonvertacijaiIIntegeri = "1ooooo tukstanciu";

if (int.TryParse(blogasStringasKonvertacijaiIIntegeri, out parsedInt)) // pavizdys kai konvertuoti, nesigaus.
{
    myFirstInt = parsedInt;
    System.Console.WriteLine(myFirstInt);
}
else
{
    System.Console.WriteLine($"Nesigavo isparsinti {blogasStringasKonvertacijaiIIntegeri} i skaiciu");
}