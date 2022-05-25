using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Colections.addressBook
{
    public class AddressLine
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public AddressLine(string name, string surname, string city, string phoneNumber) 
        {
            Name = name;
            Surname = surname;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }

}
