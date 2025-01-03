using SQLite;
using Biblioteca.Models;
using System.Collections.ObjectModel;

namespace Biblioteca.ViewModels
{
    public static class LivrosViewModel
    {
        public static ObservableCollection<Livro> acervoLivros { get; set; } = new ObservableCollection<Livro>();
        public static Livro LivroSelecionado { get; set; } = new Livro();
        private static string filename = "acervo.db3";
        public static string DBPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
        private static SQLiteConnection conn;
        public static void Init()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection(DBPath);
                try
                {
                    conn.CreateTable<Livro>();
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
        }
        public static ObservableCollection<Livro> ListarLivros()
        {
            Init();
            acervoLivros.Clear();
            List<Livro> a = conn.Table<Livro>().OrderBy(l=> l.NomeLivro).ToList();
            foreach(Livro l in a)
            {
                acervoLivros.Add(l);
            }
            return acervoLivros;
        }
        public static int AdicionarLivro(Livro novoLivro)
        {
            int res = -1;
            Init();

            try
            {
                res = conn.Insert(novoLivro);
            }
            catch(Exception e)
            {
                return res;
            }
            
            if (res > 0)
            {
                ListarLivros();
            }
            return res;
        }
        public static Livro ProcurarLivro(Livro achar)
        {
            Init();
            return conn.Table<Livro>().FirstOrDefault(a=> a.ISBN == achar.ISBN);
        }
        public static int AtualizarLivro(Livro livroAtualizado)
        {
            Init();

            int res = conn.Update(livroAtualizado);
            if (res > 0)
            {
                var livro = acervoLivros.FirstOrDefault(l => l.ISBN == livroAtualizado.ISBN);
                if (livro != null)
                {
                    int index = acervoLivros.IndexOf(livro);
                    acervoLivros[index] = livroAtualizado;
                }
            }
            return res;
        }
        public static int ApagarLivro(Livro apagarLivro)
        {
            Init();
            int res = conn.Delete(apagarLivro);

            if (res > 0)
            {
                acervoLivros.Remove(apagarLivro);
            }
            return res;
        }
    }
}