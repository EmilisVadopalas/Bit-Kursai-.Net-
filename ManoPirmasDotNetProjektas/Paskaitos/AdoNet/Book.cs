using System.ComponentModel.DataAnnotations.Schema;

namespace ManoPirmasDotNetProjektas.Paskaitos.AdoNet
{

    [Table("Knygos")]
    public class Book
    {
        [Column("KnygosID")]
        public int BookId { get; set; }

        [Column("Pavadinimas")]
        public string Name { get; set; }

        [Column("Žanras")]
        public string Type { get; set; }

        [Column("Puslapių kiekis")]
        public int PuslapiųKiekis { get; set; }

        [Column("Originalo_kalba")]
        public string OriginalLanguage { get; set; }

        [Column("AutoriusID")]
        public int AuthorId { get; set; }
    }

}
