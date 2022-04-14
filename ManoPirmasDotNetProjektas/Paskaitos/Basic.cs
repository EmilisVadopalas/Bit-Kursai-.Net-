using System;
using System.Collections.Generic;

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
            if (OperatorsTestOne() || OperatorsTestTwo())
            {
                Console.WriteLine("True");
            }

            Console.WriteLine("\n \n BitWise OR \n \n ");

            if (OperatorsTestOne() | OperatorsTestTwo())
            {
                Console.WriteLine("True");
            }

            //one line comment: du slasai //

            /*
              
              multi line komentaras              
             
            */
        }

        /// <summary>
        /// sitas metodas iskvies uzduotis kurias darem per antra paskaita, kurioje aptareme C# pagrindus.
        /// </summary>
        public static void AntrosPaskaitosUzduotys()
        {
            ///
            ///IFs
            ///
            #region If's

            // if statement
            if (1 == 1)
            {
                Console.WriteLine("1 == 1 is true");
            }

            //if-else statement
            if (1 == 2)
            {
                Console.WriteLine("1 == 2 is true");
            }
            else
            {
                Console.WriteLine("1 == 2 is false");
            }

            //nested if statement
            if (1 == 1)
            {
                if (2 == 2)
                {
                    if (3 == 3)
                    {
                        Console.WriteLine("1 == 1 AND 2 == 2 AND 3 == 3 is true");
                    }
                }
            }
            //same as:
            if (1 == 1 && 2 == 2 && 3 == 3)
            {
                Console.WriteLine("1 == 1 AND 2 == 2 AND 3 == 3 is true");
            }

            //if-else -if ladder
            if (1 == 2)
            {
                Console.WriteLine("1 == 2 is true");
            }
            else if (2 == 2)
            {
                Console.WriteLine("2 == 2 is true");
            }
            else
            {
                Console.WriteLine("2 != 2 AND 1 != 2");
            }

            //Ternary statement (shorthand if)
            Console.WriteLine(1 == 2 ? "1 == 2 is true" : "1 == 2 is false");

            //klase.pirmaSaka.antraSaka.TreciaSaka.reikiamaReiksme;
            //klase?.pirmaSaka?.antraSaka?.TreciaSaka?.reikiamaReiksme ?? "reiksme kuria naudosime jei bent viena vieta bus Null";
            #endregion

            ///
            ///SWITCHES
            ///
            #region Switches

            string testStringForSwitches = "two";


            //klasikinis switchas:
            switch (testStringForSwitches)
            {
                case "one":
                    Console.WriteLine("1");
                    break;
                case "two":
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("neither 2 nor 1");
                    break;
            }

            //klasikinis switchas su skliaustais:
            switch (testStringForSwitches)
            {
                case "one":
                    {
                        Console.WriteLine("1");
                        break;
                    }
                case "two":
                    {
                        Console.WriteLine("2");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("neither 2 nor 1");
                        break;
                    }
            }

            // expresion switchas
            Console.WriteLine(testStringForSwitches switch
            {
                "one" => "1",
                "two" => "2",
                _ => "neither 2 nor 1"
            });

            #endregion

            ///
            ///GOTO
            ///
            #region GOTO (Nenaudokit, harmfull + nieks nenaudoja)

            Console.WriteLine("start goto part");

        ineligible:
            Console.WriteLine("ineligible");

            Console.WriteLine("Enter your age:\n");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age < 18)
            {
                goto ineligible;
            }

            #endregion


            ///
            /// LOOPS
            ///
            #region Loops

            //for ciklas
            for (int i = 0; i <= 20; i++)
            {
                if (i == 6)
                {
                    continue; // Continue skipina ta specifine ciklo iteracija, ir persoka ties kita (pvz atveju, 6 neisprintins, bet ciklas suksis toliau)
                }

                if (i > 10)
                {
                    break; // break sustabdo visa cikla, po break komandos, ciklas nebesisuks
                }

                Console.WriteLine($"i = {i}");
            }

            int counter = 0;
            //while ciklas
            while (counter < 10)
            {
                counter++;

                if (counter == 7)
                {
                    break;
                }

                Console.WriteLine($"i = {counter}");
            }

            var listSkaiciai = new List<string>(); // Listo kurimo sintakse, galima belekiek veliau prideti item'u
            listSkaiciai.Add("1");
            listSkaiciai.Add("2");
            listSkaiciai.Add("3");
            listSkaiciai.Add("4");
            listSkaiciai.Add("5");
            listSkaiciai.Add("6");

            var arraySkaiciai = new string[6]; // Array deklaravimo sintakse, daugiau 6 item'u nebepridesime
                                               // deklaruojant nusprendziame kokio ilgio musu array bus
            arraySkaiciai[0] = "1";
            arraySkaiciai[1] = "2";
            arraySkaiciai[2] = "3";
            arraySkaiciai[3] = "4";
            arraySkaiciai[4] = "5";
            arraySkaiciai[5] = "6";

            //For each'ai po zodziu masyvo ar saraso pavadinimas, priesais in raktazodi rasomas, kiekvieno iraso is saraso kintamojo pavadinimas
            foreach (var listSkaicius in listSkaiciai)
            {
                Console.WriteLine($"listSkaiciu: {listSkaicius}");
            }

            foreach (var arraySkaicius in arraySkaiciai)
            {
                Console.WriteLine($"arraySkaicius: {arraySkaicius}");
            }

            counter = 0;

            //do - while ciklas
            do
            {
                counter++;

                if (counter == 7)
                {
                    break;
                }

                Console.WriteLine($"i = {counter}");
            }
            while (counter < 10);

            #endregion





            ///
            ///Uzduotys
            ///
            #region Uzduotys

            //TODO: suskurti kintamaji string skaicius, kuriam bus viena is reiksmiu:
            // "nulis"
            // "vienas"
            // "du"
            // "trys"
            // "keturi"
            // "penki"
            // "sesi"
            // "septyni"
            // "astuoni"
            // "devyni"
            // "simtas"


            //1. Naudojant tik if'us i konsole isprintinti 
            // kokia reiksme priskirta kintamajui 0-9

            //2. naudojant if-else if-else isprintinti,
            // kokia reiksme priskirta kintamajui 0-9, else 999999

            //3. perkelti sia logika i switcha (klasikini)

            //4. kintamajui (int tipo), pavadinimu "parsedSkaicius" priskirti reiksme is string "skaicius" naudojant 
            // switch expression

            //5. Susikurti stringu sarasa (List<string>), taippat susikurti stringu masyva (string[]),
            //abiems priskirti skaiciu tekstus nuo "nulis" iki "devyni"

            //6. Naudojant foreach cikla bei switch expression isprintinti visus skaiciu zodzius kaip skaicius is 5. uzduotyje susikurto
            // saraso ar masyvo
            // t.y. "keturi" => 4..

            //7.1. panaudoti ShortHand if'a t.y. ( condition ? true : false )
            //7.2. prasmingai, kur matytusis skirtumas tarp veikimo panaudoti, do-while ir while ciklus
            //7.3. prasmingai, kad matytusi skirtumas tarp veikimo, panaudoti, continue ir break, ant betkokio ciklo
            #endregion

        }

        #region Privates

        private static bool OperatorsTestOne()
        {
            Console.WriteLine("OperatorsTestOne");
            return true;
        }

        private static bool OperatorsTestTwo()
        {
            Console.WriteLine("OperatorsTestTwo");
            return true;
        }

        #endregion
    }
}
