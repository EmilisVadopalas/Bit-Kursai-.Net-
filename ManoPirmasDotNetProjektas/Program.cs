using ManoPirmasDotNetProjektas.Paskaitos;

Basic.PirmaUzduotisKetvirtosPaskaitos("tiesaiog tekstas kuri isprintis");

Basic.PirmaUzduotisKetvirtosPaskaitos("daugiau teksto keturis kartus", 4);

var skaicius = 5;

System.Console.WriteLine(skaicius);
Basic.TreciaUzduotisKetvirtosPaskaitos(ref skaicius);
System.Console.WriteLine(skaicius);

Basic.KetvirtaUzduotisKetvirtosPaskaitos(skaicius, out string daugiauMaziauLygu);
System.Console.WriteLine($"{skaicius} yra {daugiauMaziauLygu} uz nuli");

skaicius = 0;
Basic.KetvirtaUzduotisKetvirtosPaskaitos(skaicius, out daugiauMaziauLygu);
System.Console.WriteLine($"{skaicius} yra {daugiauMaziauLygu} uz nuli");

skaicius = -20;
Basic.KetvirtaUzduotisKetvirtosPaskaitos(skaicius, out daugiauMaziauLygu);
System.Console.WriteLine($"{skaicius} yra {daugiauMaziauLygu} uz nuli");


System.Console.WriteLine($"tuple: (true, \"stringas\", {skaicius})");
var result = Basic.PenktaUzduotisKetvirtosPaskaitos(true, "stringas", skaicius);
System.Console.WriteLine($"result.Item1 : {result.Item1}\n" +
                            $"result.Item2 : {result.Item2}\n" +
                            $"result.Item3 : {result.Item3}\n");

System.Console.WriteLine($"skaiciu 1, 2, 3, 4, 5, 6, 7, 8, 9  ," +
    $" suma: { Basic.SestaUzduotisKetvirtosPaskaitos(1, 2, 3, 4, 5, 6, 7, 8, 9)}");

Basic.SeptintaUzduotisKetvirtosPaskaitos("arrow or in .NET called Expresion body type function");

