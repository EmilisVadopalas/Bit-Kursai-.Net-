using ManoPirmasDotNetProjektas.Paskaitos.ApiToDB;
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
        
        public Book() { }

        public Book(BookDto book)
        {
            Name = book?.title?.Substring(0, (book?.title?.Length ?? 0) > 50 ? 50 : (book?.title?.Length ?? 0)) ?? "nezinomas";
            Type = book?.type?.key?.Substring(0, (book?.type?.key?.Length ?? 0) > 50 ? 50 : (book?.type?.key?.Length ?? 0)) ?? "nezinomas";
            PageCount = book?.number_of_pages ?? 0;
            OriginalLanguage = "Unknown";

            if ((book?.AuthorDto?.Count ?? 0) == 0)
            {
                AuthorId = 1025;
            }
            else
            {
                AuthorId = book?.AuthorDto[0]?.DatabaseID ?? 1025;
            }
        }

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
