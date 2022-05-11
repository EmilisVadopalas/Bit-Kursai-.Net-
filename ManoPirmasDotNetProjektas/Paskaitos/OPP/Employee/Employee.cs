using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Employee
{
    public class Employee
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public DateOnly BirthDate { get; init; }
        public int Salary { get; init; }

        public Employee(string name, string surname, DateOnly birthDate, int salary)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Salary = salary;
        }

        public static Employee GetEmployeeFromConsoleInput()
        {
            Console.Write("Vardas: ");
            string name = Console.ReadLine();
            Console.Write("\nPavarde: ");
            string surname = Console.ReadLine();

            DateOnly birthDate = default(DateOnly);
            string date = string.Empty;

            do
            {
                Console.Write("\nGimimo data: ");
                date = Console.ReadLine();
            } 
            while (!DateOnly.TryParse(date, out birthDate));

            int salary = 0;
            string textSalary = string.Empty;

            do
            {
                Console.Write("\nAlga: ");
                textSalary = Console.ReadLine();
            }
            while (!int.TryParse(textSalary, out salary));

            return new Employee(name, surname, birthDate, salary);
        }
    }
}
