using System;
using System.Collections.Generic;
using ManoPirmasDotNetProjektas.Extensions;

namespace ManoPirmasDotNetProjektas.Paskaitos
{
    internal class Basic
    {
        /// <summary>
        /// sitas metodas iskvies uzduotis kurias darem per pirma paskaita, kurioje aptareme C# pagrindus.
        /// </summary>
        /// <param name="param">tiesiog parametras</param>
        public void PirmosPaskaitosUzduotys(string param = "default tekstas")
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
        public void AntrosPaskaitosUzduotys()
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

            var skaicius = "penki";

            Console.WriteLine($"\n\n\n0:\nNumber chosen {skaicius}");

            //1. Naudojant tik if'us i konsole isprintinti 
            // kokia reiksme priskirta kintamajui 0-9

            Console.WriteLine("\n\n\n1:\n");

            if (skaicius == "nulis")
            {
                Console.WriteLine(0);
            }
            if (skaicius == "vienas")
            {
                Console.WriteLine(1);
            }
            if (skaicius == "du")
            {
                Console.WriteLine(2);
            }
            if (skaicius == "trys")
            {
                Console.WriteLine(3);
            }
            if (skaicius == "keturi")
            {
                Console.WriteLine(4);
            }
            if (skaicius == "penki")
            {
                Console.WriteLine(5);
            }
            if (skaicius == "sesi")
            {
                Console.WriteLine(6);
            }
            if (skaicius == "septyni")
            {
                Console.WriteLine(7);
            }
            if (skaicius == "astuoni")
            {
                Console.WriteLine(8);
            }
            if (skaicius == "devyni")
            {
                Console.WriteLine(9);
            }



            //2. naudojant if-else if-else isprintinti,
            // kokia reiksme priskirta kintamajui 0-9, else 999999

            Console.WriteLine("\n\n\n2:\n");

            if (skaicius == "nulis")
            {
                Console.WriteLine(0);
            }
            else if (skaicius == "vienas")
            {
                Console.WriteLine(1);
            }
            else if (skaicius == "du")
            {
                Console.WriteLine(2);
            }
            else if (skaicius == "trys")
            {
                Console.WriteLine(3);
            }
            else if (skaicius == "keturi")
            {
                Console.WriteLine(4);
            }
            else if (skaicius == "penki")
            {
                Console.WriteLine(5);
            }
            else if (skaicius == "sesi")
            {
                Console.WriteLine(6);
            }
            else if (skaicius == "septyni")
            {
                Console.WriteLine(7);
            }
            else if (skaicius == "astuoni")
            {
                Console.WriteLine(8);
            }
            else if (skaicius == "devyni")
            {
                Console.WriteLine(9);
            }
            else
            {
                Console.WriteLine(999999);
            }

            //3. perkelti sia logika i switcha (klasikini)

            Console.WriteLine("\n\n\n3:\n");

            switch (skaicius)
            {
                case "nulis":
                        Console.WriteLine(0);
                        break;
                case "vienas":
                        Console.WriteLine(1);
                        break;
                case "du":
                        Console.WriteLine(2);
                        break;
                case "trys":
                        Console.WriteLine(3);
                        break;
                case "keturi":
                        Console.WriteLine(4);
                        break;
                case "penki":
                        Console.WriteLine(5);
                        break;
                case "sesi":
                        Console.WriteLine(6);
                        break;
                case "septyni":
                        Console.WriteLine(7);
                        break;
                case "astuoni":
                        Console.WriteLine(8);
                        break;
                case "devyni":
                        Console.WriteLine(9);
                        break;
                default:
                        Console.WriteLine(999999);
                        break;
            }

            //4. kintamajui (int tipo), pavadinimu "parsedSkaicius" priskirti reiksme is string "skaicius" naudojant 
            // switch expression

            Console.WriteLine("\n\n\n4:\n");

            var parsedSkaicius = (skaicius) switch
            {
                "nulis" => 0,
                "vienas" => 1,
                "du" => 2,
                "trys" => 3,
                "keturi" => 4,
                "penki" => 5,
                "sesi" => 6,
                "septyni" => 7,
                "astuoni" => 8,
                "devyni" => 9,
                _ => 999999
            };

            Console.WriteLine($"Switch expression parsed number: {parsedSkaicius}");

            //5. Susikurti stringu sarasa (List<string>), taippat susikurti stringu masyva (string[]),
            //abiems priskirti skaiciu tekstus nuo "nulis" iki "devyni"            

            Console.WriteLine("\n\n\n5:\n(no console prints)");

            var stringList = new List<string>();
            stringList.Add("nulis");
            stringList.Add("vienas");
            stringList.Add("du");
            stringList.Add("trys");
            stringList.Add("keturi");
            stringList.Add("penki");
            stringList.Add("sesi");
            stringList.Add("septyni");
            stringList.Add("astuoni");
            stringList.Add("devyni");

            var stringArray = new string[10];
            stringArray[0] = "nulis";
            stringArray[1] = "vienas";
            stringArray[2] = "du";
            stringArray[3] = "trys";
            stringArray[4] = "keturi";
            stringArray[5] = "penki";
            stringArray[6] = "sesi";
            stringArray[7] = "septyni";
            stringArray[8] = "astuoni";
            stringArray[9] = "devyni";

            //6. Naudojant foreach cikla bei switch expression isprintinti visus skaiciu zodzius kaip skaicius is 5. uzduotyje susikurto
            // saraso ar masyvo
            // t.y. "keturi" => 4..

            Console.WriteLine("\n\n\n6:\n");

            foreach (string str in stringArray)
            {
                Console.WriteLine((str) switch
                {
                    "nulis" => 0,
                    "vienas" => 1,
                    "du" => 2,
                    "trys" => 3,
                    "keturi" => 4,
                    "penki" => 5,
                    "sesi" => 6,
                    "septyni" => 7,
                    "astuoni" => 8,
                    "devyni" => 9,
                    _ => 999999
                });
            }

            //7.1. panaudoti ShortHand if'a t.y. ( condition ? true : false )

            Console.WriteLine("\n\n\n7.1:\n");

            var alwaysFalse = true == false ? true : false;

            Console.WriteLine($"alwaysFalse (shorthand): {alwaysFalse}");

            //7.2. prasmingai, kur matytusis skirtumas tarp veikimo panaudoti, do-while ir while ciklus

            Console.WriteLine("\n\n\n7.2:\n");

            //will not print 
            counter = 0;
            while(counter > 5)
            {
                counter++;
                Console.WriteLine($"counter (while): {counter}");
            }

            //will print nuber 1
            do
            {
                counter++;
                Console.WriteLine($"counter (do-while): {counter}");
            }
            while (counter > 5);

            //7.3. prasmingai, kad matytusi skirtumas tarp veikimo, panaudoti, continue ir break, ant betkokio ciklo

            Console.WriteLine("\n\n\n7.3:\n");

            for(int i = 0; i < 1000000000; i++)
            {              
                if (i % 2 == 1) //skipinam nelyginius skaicius
                {
                    continue;
                }

                if(i > 100) //nenorim kad printintu milijarda skaitmenu, tai stabdom ties simtu.
                {
                    break;
                }

                Console.WriteLine($"i = {i}");
            }


            #endregion

        }

        /// <summary>
        /// sitas metodas iskvies uzduotis kurias darem per trecia paskaita, kurioje aptareme C# pagrindus.
        /// </summary>
        public void TreciosPaskaitosUzduotys()
        {
            ///
            /// ARRAYS
            ///
            #region Arrays

            ///
            ///One dimentional
            ///

            //kintamojo sukurimas
            var singleDimensionStringArrray = new string[8];

            //kintamojo sukurimas, reiksmes priskirimas
            var singleDimensionStringArrrayWithValues = new string[] {"a","s","8","h","test","sd" };

            //kintamojo sukurimas, reiksmes priskirimas, alternatyva, bet nebegalima kairej var rasyt
            string[] singleDimensionStringArrrayWithValuesShorter = { "a", "s", "8", "h", "test", "sd" };

            ///
            /// MULTI DIMENTIONAL
            ///

            //kintamojo sukurimas
            var multiDimensionStringArrray = new string[6,7];

            //kintamojo sukurimas, reiksmes priskirimas
            var multiDimensionStringArrrayWithValues = new string[,] 
            { 
                { "a", "s", "8", "h", "test", "sd" }, 
                { "1a", "1s", "18", "1h", "1test", "1sd" } 
            };

            Console.WriteLine("multiDimensionStringArrrayWithValues" + multiDimensionStringArrrayWithValues[1,0]);

            //kintamojo sukurimas, reiksmes priskirimas, alternatyva, bet nebegalima kairej var rasyt
            string[,] multiDimensionStringArrrayWithValuesShorter = 
            { 
                {  // 0
                    "a",     //[0,0]
                    "s",     //[0,1]
                    "8",     //[0,2]
                    "h",     //[0,3]
                    "test",  //[0,4]
                    "sd"     //[0,5]
                }, 


                { // 1
                    "a",    //[1,0]
                    "s",    //[1,1]
                    "8",    //[1,2]
                    "h",    //[1,3]
                    "test", //[1,4]
                    "sd"    //[1,5]
                } 
            };

            ///
            /// JAGGED ARRAY
            ///

            //kintamojo sukurimas
            var jaggedDimensionStringArrray = new string[2][];

            //kintamojo sukurimas, reiksmes priskirimas
            var jaggedDimensionStringArrrayWithValues = new string[2][] 
            { 
                new string[] { "a", "s", "8", "h", "test", "sd" }, 
                new string[] { "1a", "1s", "18", "1h", "1test", "1sd","1kk" } 
            };

            //kintamojo sukurimas, reiksmes priskirimas, alternatyva, bet nebegalima kairej var rasyt
            string[][] jaggedDimensionStringArrrayWithValuesShorter = 
            { 
                // 0
                new string[] { 
                    "a",    //[0][0]
                    "s",    //[0][1]
                    "8",    //[0][2]
                    "h",    //[0][3]
                    "test", //[0][4]
                    "sd"    //[0][5]
                }, 

                // 1
                new string[] {
                    "1a",       //[1][0]
                    "1s",       //[1][1]
                    "18",       //[1][2]
                    "1h",       //[1][3]
                    "1test",    //[1][4]
                    "1sd",      //[1][5]
                    "1kk"       //[1][6]
                } 
            };

            Console.WriteLine("jaggedDimensionStringArrrayWithValuesShorter   " + jaggedDimensionStringArrrayWithValuesShorter[1][2]);

            #endregion

            ///
            /// UZDUOTYS
            ///
            #region Uzduotys

            //1. susikurti masyva su 100 skaitmenu,
            // (var myGrades = new int[100];), uzpildyti masyva atsitiktiniais skaiciai, galima naudoti random funkcija.

            var myGrades = new int[100];
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                myGrades[i] = rnd.Next(10);
            }

            //2.1. apsakaiciuotu pazymiu bendra suma sum()
            Console.WriteLine($"\n2.1. suma: {myGrades.Suma()}\n");

            //2.2. apskaiciuoti didziausia pazymi max()
            Console.WriteLine($"\n2.1. dydziausias Skaicius: {myGrades.DydziausiasSkaicius()}\n");

            //2.3. apskaiciuoti maziausia pazymi min()
            Console.WriteLine($"\n2.1. maziausias Skaicius: {myGrades.MaziausiasSkaicius()}\n");

            //2.4. apskaiciuoti vidurki avg()
            Console.WriteLine($"\n2.1. Vidurkis: {myGrades.Vidurkis()}\n");

            //2.5. surasta median https://www.investopedia.com/terms/m/median.asp tai 49ir50 sudeti ir / 2  median()
            Console.WriteLine($"\n2.1. Mediana: {myGrades.Mediana()}\n");

            //2.6. surasti dazniausiai pasikartojanti (mode())
            Console.WriteLine($"\n2.1. Dazniausiai pasikartojantis pazimys: {myGrades.DazniausiaiPasikartojantis()}\n");

            //2.7. (kas norit) rast saraso standart diviaton
            Console.WriteLine($"\n2.1. Standartinis nuokripis: {myGrades.StandartinisNuokripis()}\n");

            //2.8. sort algoritma koki norit (issortint nuo maziausio iki dydziausio)
            Console.WriteLine($"\n2.1. Sorted: {myGrades.MyBubbleSort().ToMyString()}\n");

            //3. Sukurti cikla kuris isvardija kas N-taji nari masyve (N reiksme dinamine, ja galima keisti),
            // naudojant foreach cikla.

            var nthNumber = 4;

            Console.WriteLine($"Print Nth number Nth - {nthNumber}");

            myGrades.PrintNthNumbers(nthNumber);

            #endregion
        }

        //1. Sukurti metoda kuris isprintina paduota teksta, i konsole
        public void PirmaUzduotisKetvirtosPaskaitos(string tekstas)
        {
            Console.WriteLine(tekstas);
        }

        //2. sukurti kelis metodus topaciu pavadinimu bet skirtingais parametrais
        // overloading (funkcija is pirmos uzduoties papildyti, dviem stringais, arba stringais ir intais
        public void PirmaUzduotisKetvirtosPaskaitos(string tekstas, int kiekis)
        {
            for (int i = 0; i < kiekis; i++)
            {
                Console.WriteLine(tekstas);
            }
        }

        //3. sukurti metoda kuris paima int'o referenca ir su juo atlieka veiksmus, (return type void), bet tuopaciu pakeicia ta kintimaji
        // (ref raktazodis)
        public void TreciaUzduotisKetvirtosPaskaitos(ref int skaicius)
        {
            skaicius = skaicius * skaicius;
        }

        //4. Parasyti funkcija su out parametru
        public bool KetvirtaUzduotisKetvirtosPaskaitos(int kiekis, out string daugiauMaziauLygu)
        {
            daugiauMaziauLygu = string.Empty;

            if (kiekis == 0)
            {
                daugiauMaziauLygu = "Lygu";

                return true;
            } 
            else if (kiekis > 0)
            {
                daugiauMaziauLygu = "Daugiau";

                return false;
            } 
            else
            {
                daugiauMaziauLygu = "Maziau";

                return false;
            }
        }

        //5. parasyti funkcija su tuple return tipu
        public (bool, string, int) PenktaUzduotisKetvirtosPaskaitos(bool a, string b, int c)
        {
            return (a, b, c);
        }

        //6. parasyti funkcija su varArgs, (params raktazodis)
        public int SestaUzduotisKetvirtosPaskaitos(params int[] arguments)
        {
            return arguments.Suma();
        }

        //7. Expresion body funkcija (kaip JS buvo Arrow funkcijos)
        public void SeptintaUzduotisKetvirtosPaskaitos(string justPrintMe) => 
            Console.WriteLine(justPrintMe);

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
