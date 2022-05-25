using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections.addressBook
{
    public class AddressBook 
    { 
        private List<AddressLine> _lines;

        public AddressBook()
        {
            var randomGenerator = new Random();

            _lines = new List<AddressLine>();
            _lines.Add(new AddressLine("Arunas","Simonaitis","Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Modestas", "Pilypaitis", "Kaunas", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Benediktas", "Antaninas", "Klaipeda", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Virgilijus", "Monikaitis", "Kaunas", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Valentinas", "Anzelikas", "Klaipeda", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Vladimiras", "Agnius", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Edvinas", "Erikaitis", "Kaunas", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Aleksandra", "Aldonaviciene", "Siauliai", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Alfredas", "Stefanautas", "Panevezys", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Daina", "Renetaite", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Ignas", "Kazimeras", "Kaunas", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Goda", "Sofijiene", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Janina", "Konstantinaite", "Klaipeda", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Laimute", "Vilmantaite", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Virgilijus", "Nijolius", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Daina", "Laurynaikiene", "Kaunas", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Vladimiras", "Agniuskaitis", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Valentinas", "Adniskis", "Klaipeda", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Vladimiras", "Agnetikis", "Vilnius", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Edvinas", "Erikaitis", "Kaunas", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Aleksandra", "Aldonavitaite", "Siauliai", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Alfredas", "Stefanauskas", "Panevezys", randomGenerator.Next(860000000, 869999999).ToString()));
            _lines.Add(new AddressLine("Daina", "Renetaite", "Siauliai", randomGenerator.Next(860000000, 869999999).ToString()));
        }

        public AddressBook(IEnumerable<AddressLine> lines)
        {
            _lines = lines?.ToList() ?? null;
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            if (_lines == null) return string.Empty;

            foreach (var line in _lines)
            {
                str.Append($"{line.Name} {line.Surname} {line.City} {line.PhoneNumber}\n");
            }

            return str.ToString();
        }

        public int GetNumberOfPeopleLivingInCity(string city) => 
            _lines.Where(line => line.City == city).Count();

        public IEnumerable<AddressLine> GetLines(string name, string surname) =>
            _lines.Where(line => line.Name == name && line.Surname == surname);

        public IEnumerable<AddressLine> GetLines(string name, string surname, string city) =>
            _lines.Where(line => line.Name == name && line.Surname == surname && line.City == city);

        public IEnumerable<AddressLine> OrderByName =>
           _lines.OrderBy(line => line.Name);

        public IEnumerable<AddressLine> OrderByCity =>
           _lines.OrderBy(line => line.City);

        public IEnumerable<AddressLine> OrderByNameAndCity =>
            _lines.OrderBy(line => line.Name).ThenBy(line => line.City);

        public IEnumerable<AddressLine> OrderByCityAndName =>
           _lines.OrderBy(line => line.City).ThenBy(line => line.Name);

    }

}
