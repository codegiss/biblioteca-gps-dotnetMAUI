using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Biblioteca.Models
{
    [Table("Livros")]
    public class Livro
    {
        [PrimaryKey]
        public string ISBN { get; set; }
        [Unique]
        public string NomeLivro { get; set; }
        public string NomeAutor { get; set; }
        public string EmailAutor { get; set; }

        public Livro(string isbn, string nomeLivro, string nomeAutor, string emailAutor)
        {
            ISBN = isbn;
            NomeLivro = nomeLivro;
            NomeAutor = nomeAutor;
            EmailAutor = emailAutor;
        }
        public Livro() { }
    }
}
