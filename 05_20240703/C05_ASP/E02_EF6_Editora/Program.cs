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

                editora.EditoraName = "editora 1";
                db.Editora.Add(editora);
                db.SaveChanges();

                var queryEditora = db.Editora.Select(e => e).OrderBy(e => e.EditoraId);

                Utility.WriteTitle("Editora");
                Utility.WriteMessage("\n");

                foreach (var item in queryEditora)
                {
                    Utility.WriteMessage($"{item.EditoraId} - {item.EditoraName}", "", "\n");
                }

                Tipo tipo1 = new Tipo();
                Tipo tipo2 = new Tipo();
                Tipo tipo3 = new Tipo();

                tipo1.Nome = "Romance";
                tipo2.Nome = "Infantil";
                tipo3.Nome = "Acção";

                db.Tipo.Add(tipo1);
                db.Tipo.Add(tipo2);
                db.Tipo.Add(tipo3);

                db.SaveChanges();

                var queryTipo = db.Tipo.Select(t => t).OrderBy(t => t.TipoId);

                Utility.WriteTitle("Tipo");
                Utility.WriteMessage("\n");

                foreach (var item in queryTipo)
                {
                    Utility.WriteMessage($"{item.TipoId} - {item.Nome}", "", "\n");
                }

                Livro livro = new Livro();

                livro.ISBN = "9789899706637";
                livro.Título = "Livro 1";
                livro.EditoraId = editora.EditoraId;
                livro.TipoId = tipo1.TipoId;
                db.Livro.Add(livro);
                db.SaveChanges();

                var queryLivro = db.Livro.Select(l => l).OrderBy(l => l.LivroId);

                Utility.WriteTitle("Livro");
                Utility.WriteMessage("\n");

                foreach (var item in queryLivro)
                {
                    Utility.WriteMessage($"{item.LivroId}: Editora - {item.EditoraId}, ISBN - {item.ISBN}, {item.Título}", "\n", "\n");
                }
            }

            Utility.TerminateConsole();
        }
    }
}
