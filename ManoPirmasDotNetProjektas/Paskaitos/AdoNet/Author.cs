using ManoPirmasDotNetProjektas.Paskaitos.ApiToDB;
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


        public Author(){}

        public Author(AuthorDto author)
        {
            var names = author.name.Split(' ');

            if(names.Length > 1)
            {
                Name = names[0];
                Surname = string.Empty;

                for (int i = 1; i < names.Length; i++)
                {
                    if ((Surname.Length + names[i].Length + 1) < 50) 
                    { 
                        Surname += $"{names[i]} ";
                    }
                }
            }
            else
            {
                Name = string.IsNullOrEmpty(author.name) ? "Nezinomas" : author.name.Substring(0, author.name.Length > 50 ? 50 : author.name.Length);
                Surname = string.IsNullOrEmpty(author.name) ? "Nezinomas" : author.name.Substring(0, author.name.Length > 50 ? 50 : author.name.Length);
            }

            BirthDate = author?.date is not null && DateTime.TryParse(author.date, out var authorsDate) 
                ? authorsDate
                : new DateTime(1771, 1, 1);

            var random = new Random();

            Sex = random.NextDouble() < 0.6 ? Lytis.Moteris : Lytis.Vyras;

            NativeLanguage = "Unknown";
        }        
    }

    public enum Lytis
    {
        Vyras,
        Moteris
    }
}
