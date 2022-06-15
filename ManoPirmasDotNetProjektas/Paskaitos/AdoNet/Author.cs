using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManoPirmasDotNetProjektas.Paskaitos.AdoNet
{
    [Table("Autorius")]
    public class Author 
    {
        [Column("Vardas")]
        public string Name { get; set; }

        [Column("Pavardė")]
        public string Surname { get; set; }

        [Column("Gimimo_data")]
        public DateTime BirthDate { get; set; }

        [Column("Lytis")]
        public string Sex { get; set; }

        [Column("Gimtoji_kalba")]
        public string NativeLanguage { get; set; }
    }
}
