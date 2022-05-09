using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Structs
{
    public struct PersonNameStructure
    {
        public string FirsName { get; init; }
        public string[] MiddleName { get; init; }
        public string LastName { get; init; }

        public override string ToString() =>
            $"{FirsName}{(MiddleName is null ? string.Empty : $" {string.Join(" ", MiddleName)}")} {LastName}";
    }
}
