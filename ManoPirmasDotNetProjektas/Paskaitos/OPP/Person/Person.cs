using System;

namespace ManoPirmasDotNetProjektas.Paskaitos.OPP
{
    public class Person
    {
        public FullName FullName { get; set; }        
        public DateTime DateOfBirth { get; init; }
        public bool IsMale { get; set; }

        public string Name
        {
            get
            {
                return FullName.Name;
            }
        }
        public string Surname
        {
            get
            {
                return FullName.Surname;
            }
        }
        public int Age
        {
            get
            {
                return GetAge();
            }
        }

        public Person() { }
        public Person(string name, string surname)
            : this(name, surname, true, new DateTime(1991, 01, 01)) { }
        public Person(string name, string surname, bool ismale)
            : this(name, surname, ismale, new DateTime(1991, 01, 01)) { }
        public Person(string name, string surname, DateTime dateOfBirth)
            : this(name, surname, true, dateOfBirth) { }
        public Person(string name, string surname, bool ismale, DateTime dateOfBirth)
        {
            FullName = new FullName(name, surname); 
            IsMale = ismale;
            DateOfBirth = dateOfBirth;
        }

        public string GetFullNameWithInitials() =>
            $"{GetFirstLetter(Name)}{GetFirstLetter(Surname)}, {Name} {Surname} ";

        #region Privates

        private char GetFirstLetter(string name) =>
            string.IsNullOrWhiteSpace(name)
                ? default(char)
                : name.Trim()[0];

        private int GetAge()
        {
            var now = DateTime.Now;
            var yearDiff = now.Year - DateOfBirth.Year;

            if (now.Month > DateOfBirth.Month)
            {
                return yearDiff;
            }
            else if (now.Month == DateOfBirth.Month)
            {
                return now.Day > DateOfBirth.Day
                    ? yearDiff
                    : --yearDiff;
            }
            else
            {
                return --yearDiff;
            }
        }

        #endregion
    }
}