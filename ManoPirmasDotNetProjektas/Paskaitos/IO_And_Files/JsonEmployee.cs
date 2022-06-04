using System;

namespace ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files
{
    public class JsonEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal SalaryBrutto { get; set; }
        public int Taxes { get; set; }
        public decimal SalaryNeto { get; set; }

        public JsonEmployee()
        {
        }

        public JsonEmployee(CsvEmployee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            DateOfBirth = employee.DateOfBirth;
            SalaryBrutto = employee.SalaryBrutto;
            Taxes = employee.Taxes;
            SalaryNeto = employee.SalaryBrutto * ((decimal)(100 - employee.Taxes) / 100);
        }
    }
}
