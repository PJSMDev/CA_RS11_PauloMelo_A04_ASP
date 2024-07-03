using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E02_EF6_Editora.Class;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E02_EF6_Editora.Context
{

    internal class EditoraContext : DbContext
    {

        public EditoraContext() : base("EditoraEntitiesCS")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Editora> Editora { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
    }
}
