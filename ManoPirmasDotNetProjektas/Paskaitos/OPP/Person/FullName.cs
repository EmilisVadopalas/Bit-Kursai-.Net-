namespace ManoPirmasDotNetProjektas.Paskaitos.OPP
{
    public class FullName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string[] MiddleNames { get; set; }

        public FullName(string name, string surname, string[] middleNames = null)
        {
            Name = name;
            Surname = surname;
            MiddleNames = middleNames;
        }

        public string GetFullName()
        {
            return $"{Name}{(MiddleNames is null ? string.Empty : $" {string.Join(" ", MiddleNames)}")} {Surname}";
        }

        public int GetFullNameLenght()
        {
            return GetFullName().Length;
        }
    }
}