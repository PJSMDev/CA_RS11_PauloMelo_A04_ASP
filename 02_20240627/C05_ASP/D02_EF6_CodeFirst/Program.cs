using D00_Utility;
using D02_EF6_CodeFirst.Context;
using D02_EF6_CodeFirst.Class;
using D02_EF6_CodeFirst.Context;
using System.Linq;

namespace D02_EF6_CodeFirst
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utility.SetUnicodeConsole();

            using (var db = new BlogContext())
            {

                #region Blog

                // Criar
                Blog blog = new Blog();

                blog.Name = "Blog 1";

                db.Blog.Add(blog);

                db.SaveChanges();

                // Listar
                var queryBlogs = db.Blog.Select(b => b).OrderBy(b => b.BlogID);

                Utility.WriteTitle("Blog\n\n");

                foreach (var item in queryBlogs)
                {

                    Utility.WriteMessage($"Blog: {item.BlogID} - {item.Name}", "", "\n");

                }
                #endregion

                #region New Post

                // Criar
                //Post post = new Post();

                //post.Title = "";

                // Listar

                #endregion
            }

            Utility.TerminateConsole();
        }
    }
}
