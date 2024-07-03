using D00_Utility;
using E02_EF6_Editora.Class;
using E02_EF6_Editora.Context;
using System.Linq;

namespace E02_EF6_Editora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility.SetUnicodeConsole();

            using (var db = new EditoraContext())
            {
                Editora editora = new Editora();

                editora.Nome = "editora 1";
                db.Editora.Add(editora);
                db.SaveChanges();

                var queryEditora = db.Editora.Select(e => e).OrderBy(e => e.EditoraID);

                Utility.WriteTitle("Editora");

                foreach (var item in queryEditora)
                {
                    Utility.WriteMessage($"{item.EditoraID} - {item.Nome}", "", "\n");
                }

                Utility.WriteMessage("\n");

                Livro livro = new Livro();

                livro.ISBN = "9789899706637";
                livro.Titulo = "Livro 1";
                livro.EditoraID = editora.EditoraID;
                db.Livro.Add(livro);
                db.SaveChanges();

                var queryLivro = db.Livro.Select(l => l).OrderBy(l => l.LivroID);

                Utility.WriteTitle("Livro");

                foreach (var item in queryLivro)
                {
                    Utility.WriteMessage($"{item.LivroID}: Editora - {item.EditoraID}, ISBN - {item.ISBN}, {item.Titulo}", "\n", "\n");
                }

                Utility.WriteMessage("\n");

                Tipo tipo01 = new Tipo();

                tipo01.LivroID = livro.LivroID;
                tipo01.TipoLivro = "Drama";
                db.Tipo.Add(tipo01);
                db.SaveChanges();

                Tipo tipo02 = new Tipo();

                tipo02.LivroID = livro.LivroID;
                tipo02.TipoLivro = "Comédia";
                db.Tipo.Add(tipo02);
                db.SaveChanges();

                Tipo tipo03 = new Tipo();

                tipo03.LivroID = livro.LivroID;
                tipo03.TipoLivro = "Biografia";
                db.Tipo.Add(tipo03);
                db.SaveChanges();

                var queryTipo = db.Tipo.Select(t => t).OrderBy(t => t.TipoID);

                Utility.WriteTitle("Tipo");

                foreach (var item in queryTipo)
                {
                    Utility.WriteMessage($"{item.TipoID}: {item.TipoLivro}", "\n", "\n");
                }
            }

            Utility.TerminateConsole();
        }
    }
}
