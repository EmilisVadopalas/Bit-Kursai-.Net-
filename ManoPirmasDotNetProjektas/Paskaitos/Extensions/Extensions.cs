using ManoPirmasDotNetProjektas.Paskaitos.OPP.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Extensions
{
    public static class Extensions
    {
        public static string ToWord(this int number)
        {
            if(number == 1)
            {
                return "vienas";
            }
            
            if(number == 2)
            {
                return "du";
            }

            return "daugiau nei du arba maziau nei vienas";
        }

        public static string ToMyString(this int[] array)
        {
            string str = string.Empty;

            foreach (int i in array)
            {
                str += $"\n{i}";
            }

            return str;
        }

        public static int Suma(this int[] array)
        {
            var sum = 0;

            foreach (int i in array)
            {
                sum += i;
            }

            return sum;
        }

        public static int DydziausiasSkaicius(this int[] array)
        {
            var maxNumber = -9999999;

            foreach (int i in array)
            {
                if (i > maxNumber)
                {
                    maxNumber = i;
                }
            }

            return maxNumber;
        }

        public static int MaziausiasSkaicius(this int[] array)
        {
            var minNumber = 9999999;

            foreach (int i in array)
            {
                if (i < minNumber)
                {
                    minNumber = i;
                }
            }

            return minNumber;
        }

        public static double Vidurkis(this int[] array)
        {
            return ((double)array.Suma() / array.Length);
        }

        public static int[] CloneArray(this int[] array)
        {
            var newArray = new int[array.Length];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public static int Mediana(this int[] array)
        {
            //not to sort this array, ill make a clone array
            var cloneArray = array.CloneArray();

            cloneArray.MyBubbleSort();

            var odd = (cloneArray.Length % 2) != 0;

            if (odd)
            {
                return cloneArray[(cloneArray.Length + 1) / 2];
            }
            else
            {
                int midpointUpper = cloneArray.Length / 2;
                var m1 = cloneArray[midpointUpper];
                var m2 = cloneArray[midpointUpper - 1];

                return (m1 + m2) / 2;
            }
        }

        public static int DazniausiaiPasikartojantis(this int[] array)
        {
            int countOfUniqueNumbers = 0;
            var alreadyCheckedInts = new List<int>();

            foreach (int i in array)
            {
                if (!alreadyCheckedInts.Contains(i))
                {
                    countOfUniqueNumbers++;
                    alreadyCheckedInts.Add(i);
                }
            }

            var countedNumbers = new int[countOfUniqueNumbers][];
            var counter = 0;

            foreach (int number in alreadyCheckedInts)
            {
                var instancesInList = 0;

                foreach (var instance in array)
                {
                    if (number == instance)
                    {
                        instancesInList++;
                    }
                }

                countedNumbers[counter] = new int[] { number, instancesInList };
                counter++;
            }

            int[] maxInsatances = { -10, -10 };

            foreach (var countedNumber in countedNumbers)
            {
                if (maxInsatances[1] < countedNumber[1])
                {
                    maxInsatances = countedNumber;
                }
            }

            return maxInsatances[0];
        }

        public static double StandartinisNuokripis(this int[] array) //pagal formule is https://www.scribbr.com/statistics/standard-deviation/
        {
            var avg = array.Vidurkis();
            double sumOfSquaredDeviation = 0;

            foreach (var i in array)
            {
                sumOfSquaredDeviation += ((avg - i) * (avg - i));
            }

            var varriance = sumOfSquaredDeviation / (array.Length - 1);
            var standartDeviation = Math.Sqrt(varriance);

            return standartDeviation;
        }

        public static int[] MyBubbleSort(this int[] oldArray) // pagal https://www.geeksforgeeks.org/bubble-sort/
        {
            var array = oldArray.CloneArray();

            var Unsorted = true;

            while (Unsorted)
            {
                var switchedPlacesThisItereation = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        switchedPlacesThisItereation = true;
                        var i1 = array[i];
                        var i2 = array[i + 1];

                        array[i] = i2;
                        array[i + 1] = i1;
                    }
                }

                if (!switchedPlacesThisItereation)
                {
                    Unsorted = false;
                }
            }

            return array;
        }

        public static void PrintNthNumbers(this int[] array, int nth)
        {
            var counter = 0;

            foreach (var number in array)
            {
                counter++;

                if ((counter % nth) == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
