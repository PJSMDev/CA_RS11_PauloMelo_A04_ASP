using Microsoft.EntityFrameworkCore;

namespace E03_MVC_Net_Core_Person.Models
{
    public partial class E03Context : DbContext
    {
        public E03Context()
        {
        }

        public E03Context(DbContextOptions<E03Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Alternativa: criar aqui as annotations com Fluent API
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
