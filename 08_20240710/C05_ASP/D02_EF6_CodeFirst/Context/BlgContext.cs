using D02_EF6_CodeFirst.Class;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace D02_EF6_CodeFirst.Context
{

    internal class BlogContext : DbContext
    {

        // No construtor passamos o nome da connectionstring registada no App.config
        public BlogContext() : base("BlogEntitiesCS") 
        { }

        // Método executado no startuo: criar tabelas, criar relações, criar constraints,chaves, ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desativar a pluralização das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        // Dbsets (representação em memória das tabelas)
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }
    }
}
