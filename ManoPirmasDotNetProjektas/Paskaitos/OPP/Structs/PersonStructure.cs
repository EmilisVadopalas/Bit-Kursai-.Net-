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
        public PersonNameStructure Name { get; init; }
        public DateOnly BirthDate { get; init; }
        public Sex Sex { get; init; }

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
