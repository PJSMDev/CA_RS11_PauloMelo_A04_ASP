using D00_Utility;
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
                var queryBlogs01 = db.Blog.Select(b => b).OrderBy(b => b.BlogID);

                Utility.WriteTitle("Blog\n");

                foreach (var item in queryBlogs01)
                {

                    Utility.WriteMessage($"Blog: {item.BlogID} - {item.Name}", "", "\n");

                }
                #endregion

                #region New Posts

                int currentBlogID = 1;

                // Criar
                Post post01 = new Post();

                post01.Title = "Post 1";

                post01.Content = "Conteúdo do post 1";

                post01.BlogID = currentBlogID;

                db.Post.Add(post01);

                Post post02 = new Post();

                post02.Title = "Post 2";

                post02.Content = "Conteúdo do post 2";

                post02.BlogID = currentBlogID;

                db.Post.Add(post02);

                db.SaveChanges();

                // Listar
                // Incluir apenas os blogs com posts
                var queryBlogs02 = db.Blog.Include("Post").OrderBy(b => b.BlogID);


                Utility.WriteTitle("Blogs + Posts");

                foreach (var item in queryBlogs02) 
                {
                    Utility.WriteMessage($"Blog: {item.BlogID} - {item.Name}", "", "\n");

                    foreach (var post in blog.Post)
                    {
                        Utility.WriteMessage($"\t\tPost: {post.PostID} - {post.Title} - {post.Content}", "", "\n");
                    }
                }

                #endregion
            }

            Utility.TerminateConsole();
        }
    }
}
