using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManoPirmasDotNetProjektas.Paskaitos.AdoNet
{
    [Table("Autorius")]
    public class Author
    {
        [Column("AutoriusID")]
        [Key]
        public int Id { get; set; }

        [Column("Vardas")]
        public string Name { get; set; }

        [Column("Pavardė")]
        public string Surname { get; set; }

        [Column("Gimimo_data")]
        public DateTime BirthDate { get; set; }

        [Column("Lytis")]
        public Lytis Sex { get; set; }

        [Column("Gimtoji_kalba")]
        public string NativeLanguage { get; set; }


        public IEnumerable<Book> Books { get; set; }
    }

    public enum Lytis
    {
        Vyras,
        Moteris
    }
}
