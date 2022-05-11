using ManoPirmasDotNetProjektas.Paskaitos.OPP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Structs
{
    public struct PersonStructure
    {
        public PersonNameStructure Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public Sex Sex { get; set; }

        public PersonStructure(PersonNameStructure name, DateOnly birthDate, Sex sex)
        {
            Name = name;
            BirthDate = birthDate;
            Sex = sex;
        }

        public override string ToString() =>
            $"Name: {Name}" +
            $"\nBirthDate: {BirthDate:yyyy-MM-dd}" +
            $"\nSex: {Sex}";
    }
}
