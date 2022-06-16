using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManoPirmasDotNetProjektas.Paskaitos.AdoNet
{

    [Table("Knygos")]
    public class Book
    {
        [Column("KnygosID")]
        [Key]
        public int BookId { get; set; }

        [Column("Pavadinimas")]
        public string Name { get; set; }

        [Column("Žanras")]
        public string Type { get; set; }

        [Column("Puslapių_kiekis")]
        public int PageCount { get; set; }

        [Column("Originalo_kalba")]
        public string OriginalLanguage { get; set; }


        [Column("AutoriusID")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }


        public override string ToString()
        {
            return $"id: {BookId} \n" +
                $"Name: {Name} \n" +
                $"Type: {Type} \n" +
                $"Pages: {PageCount} \n" +
                $"Original language: {OriginalLanguage} \n" +
                $"Authors id: {AuthorId}";
        }
    }

}
