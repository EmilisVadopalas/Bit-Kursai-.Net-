using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.ApiToDB
{
    public class BookDto
    {
        public Type type { get; set; }
        public string title { get; set; }
        public Author[] authors { get; set; }
        public string publish_date { get; set; }
        public string[] source_records { get; set; }
        public int number_of_pages { get; set; }
        public string[] publishers { get; set; }
        public string[] isbn_10 { get; set; }
        public string[] isbn_13 { get; set; }
        public string physical_format { get; set; }
        public int?[] covers { get; set; }
        public Work[] works { get; set; }
        public string key { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public Last_Modified last_modified { get; set; }
        public List<AuthorDto> AuthorDto { get; set; }

    }
}
