using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public Character()
        {
        }

        public Character(int id, string name, string surname, DateTime birthDate)
        {
            ID = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

    }
}
