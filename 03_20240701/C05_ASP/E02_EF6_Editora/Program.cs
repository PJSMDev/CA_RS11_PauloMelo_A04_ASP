using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using E02_EF6_Editora.Class;
using E02_EF6_Editora.Context;

namespace E02_EF6_Editora
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utility.SetUnicodeConsole();

            using (var db = new EditoraContext())
            {

                #region Editora

                Editora editora = new Editora();
                editora.Nome = "Editora 1";

                db.Editora.Add(editora);

                db.SaveChanges();

                var queryEditora01 = db.Editora.Select(e => e).OrderBy(e => e.EditoraID);

                Utility.WriteTitle("Editoras\n");

                foreach (var item in queryEditora01)
                {
                    Utility.WriteMessage($"Editora: {item.EditoraID} - {item.Nome}", "", "\n");
                }

                #endregion

                #region Livro

                int blogIDAtual = 1;

                Livro livro01 = new Livro();

                livro01.EditoraID = blogIDAtual;
                livro01.ISBN = "978-3-16-148410-0";
                livro01.Titulo = "E tudo o bootcamp levou";

                db.Livro.Add(livro01);

                db.SaveChanges();

                Livro livro02 = new Livro();

                livro02.EditoraID = blogIDAtual;
                livro02.ISBN = "123-4-56-7891011-1";
                livro02.Titulo = "Livro 2";

                var queryLivros01 = db.Editora.Include("Livro").OrderBy(e => e.EditoraID);

                Utility.WriteTitle("Editora + Livros\n");

                foreach (var item in queryLivros01)
                {
                    Utility.WriteMessage($"Editora: {item.EditoraID} - {item.Nome}", "", "\n");

                    foreach (var livros in editora.Livros)
                    {
                        Utility.WriteMessage($"\t\tLivro: {livro01.LivroID} - {livro01.Titulo} - {livro01.ISBN}", "", "\n");
                    }
                }

                #endregion

            }

            Utility.TerminateConsole();
        }
    }
}
