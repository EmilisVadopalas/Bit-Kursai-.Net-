using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos
{
    public static class RegexTecher
    {
        public static void EnterAndCheckRegex()
        {
            Console.Write("Iveskite Regex: ");
            var regexPattern = Console.ReadLine();
            var regex = new Regex(regexPattern);

            Console.WriteLine("Iveskite teksta kuri regex bandys matchinti");
            Console.Write(": ");
            var text = Console.ReadLine();

            if (regex.IsMatch(text))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("tekstas atitinka regex'a");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("tekstas Neatitinka regex'o");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
