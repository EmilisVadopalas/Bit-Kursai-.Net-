using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ManoPirmasDotNetProjektas.Paskaitos.Generics.GenericsAndEventsExecutor;

namespace ManoPirmasDotNetProjektas.Paskaitos.Generics
{
    public class Darbuotojas
    {
        private static int _id = 0;

        internal event FinishJobDelegate FinishJob; 

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experiance { get; set; }

        public Darbuotojas(string name, int salary, int exp)
        {
            _id++;
            Id = _id;
            Name = name;
            Salary = salary;
            Experiance = exp;        
        }

        public void StartWork()
        {
            Console.WriteLine("pradejo darba");

            FinishJob?.Invoke();
        }

        public async Task StartWorkAsync()
        {
            Console.WriteLine("pradejo darba");

            await Task.Delay(5000);

            FinishJob?.Invoke();
        }
    }
}
