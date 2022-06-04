using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files
{
    public class CsvEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal SalaryBrutto { get; set; }
        public int Taxes { get; set; }
    }      
}
