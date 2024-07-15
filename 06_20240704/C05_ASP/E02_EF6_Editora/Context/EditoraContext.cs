using E02_EF6_Editora.Class;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E02_EF6_Editora.Context
{

    internal class EditoraContext : DbContext
    {
        // No construtor passamos o nome da connectionstring registada no App.config
        public EditoraContext() : base("EditoraEntityCS")
        { }

        // método executado no startup: criação tabelas, criar relações, chaves, ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desativar a pluralização das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        // Dbsets (representação em memória das tabelas)
        public virtual DbSet<Editora> Editora { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

    }
}
