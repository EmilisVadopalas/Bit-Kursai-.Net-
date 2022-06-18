using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.ApiToDB
{
    public class AuthorDto
    {
        public string name { get; set; }
        public string personal_name { get; set; }
        public Last_Modified last_modified { get; set; }
        public string key { get; set; }
        public string date { get; set; }
        public Type type { get; set; }
        public int id { get; set; }
        public int revision { get; set; }

        public int DatabaseID {get;set;}
    }
}
