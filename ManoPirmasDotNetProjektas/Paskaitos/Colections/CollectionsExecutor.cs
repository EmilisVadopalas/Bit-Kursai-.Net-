using ManoPirmasDotNetProjektas.Paskaitos.Colections.addressBook;
using ManoPirmasDotNetProjektas.Paskaitos.Colections.Array;
using ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus;
using ManoPirmasDotNetProjektas.Paskaitos.Colections.Lists;
using ManoPirmasDotNetProjektas.Paskaitos.OPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections
{
    public static class CollectionsExecutor
    {
        public static void Run()
        {
            //Masyvai.MasyvaiTesting();
            //Masyvai.AutobusuUzduotis();
            //Listai.AutobusuUzduotis();
            //Listai.AntraAutobusoUzduotis();
            //Dictionaries();
            //Sets();
            //AddressBookTask();

            var busR1 = new BusRoute("A1", new string[] { "99", "2", "11" });
            var person = new Person("EMilis","vadopalas");

            PrintClassName(person);
            PrintClassName(busR1);
            PrintClassName("stringsdasdasdasd");
        }

        public static void PrintClassName<T>(T generic)
        {
            Console.WriteLine(generic.GetType().Name);
        }

        public static void Dictionaries()
        {
            var busR1 = new BusRoute("A1", new string[] { "99", "2", "11" });
            var busR3 = new BusRoute("A3", new string[] { "10", "6", "9" });
            var busR2 = new BusRoute("A2", new string[] { "2", "4", "15" });

            var routes = new List<BusRoute>(new BusRoute[] { busR1, busR2, busR3 }); 

            var busRoutesFilteredLists = new Dictionary<string, List<BusRoute>>();

            busRoutesFilteredLists.Add("Number", routes.OrderBy(x => x.Number).ToList());
            busRoutesFilteredLists.Add("Origin", routes.OrderBy(x => x.Origin).ToList());
            busRoutesFilteredLists.Add("Destination", routes.OrderBy(x => x.Destination).ToList());

            PrintDictionary(busRoutesFilteredLists);
        }

        public static void Sets()
        {
            var csvFailas1 = new HashSet<string>();
            var csvFailas2 = new HashSet<string>();           
            
            csvFailas1.Add("Akropolis");
            csvFailas1.Add("Ozas");
            csvFailas1.Add("Maksima");

            csvFailas2.Add("Mega");
            csvFailas2.Add("Maksima");
            csvFailas2.Add("Panorama");

            Console.WriteLine("Before UNION:\n");
            PrintOutStrings(csvFailas1);

            csvFailas1.UnionWith(csvFailas2);

            Console.WriteLine("\n\nAfter UNION:\n");
            PrintOutStrings(csvFailas1);
        }

        private static void PrintOutStrings(IEnumerable<string> stringai)
        {
            foreach (var item in stringai)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintDictionary<TKey,TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                if (kvp.Value.GetType() == typeof(List<BusRoute>))
                {
                    var values = string.Empty;

                    foreach(var route in (IEnumerable<BusRoute>)kvp.Value)
                    {
                        values += $"Number:{route.Number}\nDestination:{route.Destination}\nOrigin:{route.Origin}\n\n";
                    }

                    Console.WriteLine($"key: {kvp.Key}  value: {values}");
                }
                else
                {
                    Console.WriteLine($"key: {kvp.Key}  value: {kvp.Value}");
                }
                }
            }

        private static void AddressBookTask()
        {
            var addressBook = new AddressBook();

            Console.WriteLine(addressBook);

            //Kiek kokiame mieste gyvena gyventoju
            Console.WriteLine($"Gyventoju Vilniuje: {addressBook.GetNumberOfPeopleLivingInCity("Vilnius")}\n");
            Console.WriteLine($"Gyventoju Kaune: {addressBook.GetNumberOfPeopleLivingInCity("Kaunas")}\n");
            Console.WriteLine($"Gyventoju Siauliuose: {addressBook.GetNumberOfPeopleLivingInCity("Siauliai")}\n");
            Console.WriteLine($"Gyventoju Panevezyje: {addressBook.GetNumberOfPeopleLivingInCity("Panevezys")}\n");
            Console.WriteLine($"Gyventoju Klaipedoje: {addressBook.GetNumberOfPeopleLivingInCity("Klaipeda")}\n");

            //paieska pagal varda:
            Console.WriteLine("\n gyventojai vardu 'Edvinas' 'Erikaitis' \n");
            Console.WriteLine(new AddressBook(addressBook.GetLines("Edvinas", "Erikaitis"))); //2

            Console.WriteLine("\n gyventojai vardu 'Goda' 'Sofijiene' \n");
            Console.WriteLine(new AddressBook(addressBook.GetLines("Goda", "Sofijiene"))); //1

            Console.WriteLine("\n gyventojai vardu 'Ignas' 'Kazimeras' \n");
            Console.WriteLine(new AddressBook(addressBook.GetLines("Ignas", "Kazimeras"))); //1

            //Orderinimas
            Console.WriteLine("\nRykiavimas pagal varda:\n");
            Console.WriteLine(new AddressBook(addressBook.OrderByName));

            Console.WriteLine("\nRykiavimas pagal miesta:\n");
            Console.WriteLine(new AddressBook(addressBook.OrderByCity));

            Console.WriteLine("\nRykiavimas pagal varda ir miesta:\n");
            Console.WriteLine(new AddressBook(addressBook.OrderByNameAndCity));

            Console.WriteLine("\nRykiavimas pagal miesta ir varda:\n");
            Console.WriteLine(new AddressBook(addressBook.OrderByCityAndName));
        }
    }
}
