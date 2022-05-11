using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP.Structs
{
    public struct PersonNameStructure
    {
        public string FirsName { get; set; }
        public string[] MiddleName { get; set; }
        public string LastName { get; set; }

        public override string ToString() =>
            $"{FirsName}{(MiddleName is null ? string.Empty : $" {string.Join(" ", MiddleName)}")} {LastName}";
    }
}
