using System;

namespace ManoPirmasDotNetProjektas.Paskaitos
{
    internal static class Basic
    {
     
        /// <summary>
        /// sitas metodas iskvies uzduotis kurias darem per pirma paskaita, kurioje aptareme C# pagrindus.
        /// </summary>
        /// <param name="param">tiesiog parametras</param>
        public static void PirmosPaskaitosUzduotys(string param = "default tekstas")
        {
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

            // C# default skaicius su kableliu yra double
            double myFirstDouble = 45.848;

            //kad skaiciu su kableliu paverstume
            //i decimal reikia ji castinti i decimal t.y. (decimal)xxx.xxxxx;
            decimal myFirstDecimal = (decimal)3.0;

            //arba skaiciaus gale parasyti m raide, nurodant
            // kad tai yra decimal tipo skaicius
            decimal mySecondDecimal = 3.0m;

            // tapati sutuaci kaip su decimal tik su float'u
            // castinam i float 
            float myFirstFloat = (float)3.0;

            //apsirasome kad tai yra float.
            float mySecondFloat = 3.0f;

            // 2 uzduotis: sukurti string tipo kintamaji (naudoti var raktazodi) kurio reiksme '5000',
            // ta kintamaji konvertuoti i int tipa ir priskirti myFirstInt kintamajui

            var penkiTukstanciai = "5000";
            myFirstInt = int.Parse(penkiTukstanciai);

            // 3 uzduotis: priskirti stringa su reiksme "6000" myFirstInt kintamajam
            // naudojant tryParse

            //galima ties out parametru tiesiai priskirti kintamaji
            if (int.TryParse("6000", out myFirstInt))
            {
                Console.WriteLine(myFirstInt);
            }

            //galima out parametre susikurti kintamaji ir ji panaudoti poto
            if (int.TryParse("7000", out int parsedInt))
            {
                myFirstInt = parsedInt;
                Console.WriteLine(myFirstInt);
            }


            // pavizdys kai konvertuoti, nesigaus.
            var blogasStringasKonvertacijaiIIntegeri = "1ooooo tukstanciu";

            if (int.TryParse(blogasStringasKonvertacijaiIIntegeri, out parsedInt))
            {
                myFirstInt = parsedInt;
                Console.WriteLine(myFirstInt);
            }
            else
            {
                Console.WriteLine($"Nesigavo isparsinti {blogasStringasKonvertacijaiIIntegeri} i skaiciu");
            }

            //Bitwise and normal OR diferences:
            if (Basic.OperatorsTestOne() || Basic.OperatorsTestTwo())
            {
                Console.WriteLine("True");
            }

            Console.WriteLine("\n \n BitWise OR \n \n ");

            if (Basic.OperatorsTestOne() | Basic.OperatorsTestTwo())
            {
                Console.WriteLine("True");
            }

            //one line comment: du slasai //

            /*
              
              multi line komentaras              
             
            */




        }

        public static bool OperatorsTestOne()
        {
            Console.WriteLine("OperatorsTestOne");
            return true;
        }

        public static bool OperatorsTestTwo()
        {
            Console.WriteLine("OperatorsTestTwo");
            return true;
        }
    }
}
