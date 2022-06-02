using ManoPirmasDotNetProjektas.Paskaitos.Colections.Bus;
using ManoPirmasDotNetProjektas.Paskaitos.Generics.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Generics
{
    public static class GenericsAndEventsExecutor
    {
        public static void Run()
        {
            //GenericsSampleCode();
            //DelegatesSampleCode();

            var letterPrintingDelegate = new PrintLettersDelegate(PrintL);
            letterPrintingDelegate += new PrintLettersDelegate(PrintA);
            letterPrintingDelegate += new PrintLettersDelegate(PrintB);
            letterPrintingDelegate += new PrintLettersDelegate(PrintA);
            letterPrintingDelegate += new PrintLettersDelegate(PrintS);

            EventSampleCode(letterPrintingDelegate);
        }

        public static void GenericsSampleCode()
        {
            var stack = new CustomStack<string>("vienas");
            stack.Push("Du");
            stack.Push("Trys");

            stack.Pop();
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            var stackInt = new CustomStack<int>(1);
            stackInt.Push(2);
            stackInt.Push(3);

            stackInt.Pop();
            Console.WriteLine(stackInt.Pop());
            Console.WriteLine(stackInt.Pop());

            var stackdouble = new CustomStack<double>(1.1);
            stackdouble.Push(2.2);
            stackdouble.Push(3.3);

            stackdouble.Pop();
            Console.WriteLine(stackdouble.Pop());
            Console.WriteLine(stackdouble.Pop());

            var myPair1 = new Pair<int, string>(16, "sesiolyka");
            var myPait2 = new Pair<int, string>(32, "Trymdu");

            var myList = new List<Pair<int, string>>(new Pair<int, string>[] { myPair1, myPait2 });

            var badPair = new Pair<string, int>("ips", 22);
        }

        public static void DelegatesSampleCode()
        {
            var employeeList = new List<Darbuotojas>(new Darbuotojas[]
            {
               new Darbuotojas("Jonas", 4000, 10),
               new Darbuotojas("Ana", 5000, 9),
               new Darbuotojas("Algirdas", 4500, 8),
               new Darbuotojas("Ona", 3850, 4),
               new Darbuotojas("Petras", 6000, 6)
            });

            var letterPrintingDelegate = new PrintLettersDelegate(PrintL);
            letterPrintingDelegate += new PrintLettersDelegate(PrintA);
            letterPrintingDelegate += new PrintLettersDelegate(PrintB);
            letterPrintingDelegate += new PrintLettersDelegate(PrintA);
            letterPrintingDelegate += new PrintLettersDelegate(PrintS);

            Console.WriteLine("\nDelegatas multi func\n");

            letterPrintingDelegate();

        }

        public static async Task EventSampleCode(PrintLettersDelegate doWhenJobFinishes)
        {
            var employeeList = new List<Darbuotojas>(new Darbuotojas[]
            {
                new Darbuotojas("Jonas", 4000, 10),
                new Darbuotojas("Ana", 5000, 9),
                new Darbuotojas("Algirdas", 4500, 8),
                new Darbuotojas("Ona", 3850, 4),
                new Darbuotojas("Petras", 6000, 6)
            });

            foreach(var empoloyee in employeeList)
            {
                empoloyee.FinishJob += () => Console.WriteLine($"{empoloyee.Name} pabaige darba !");
                empoloyee.FinishJob += () => doWhenJobFinishes();
            }

            Console.WriteLine("Darbuotojai pradeda darbus\n");

            foreach (var empoloyee in employeeList)
            {
                Console.WriteLine($"{empoloyee.Name} pradejo darba..");
                empoloyee.StartWorkAsync();
            }

            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

        }   

        private static void PrintL() => Console.WriteLine("L");
        private static void PrintA() => Console.WriteLine("A");
        private static void PrintB() => Console.WriteLine("B");
        private static void PrintS() => Console.WriteLine("S");
    }

    public delegate void PrintLettersDelegate();

    internal delegate void FinishJobDelegate();

    internal delegate void PrintLetterDelegate(char letter);

    public delegate bool IsEmployeeEligibleDelegate(Darbuotojas e);
}

