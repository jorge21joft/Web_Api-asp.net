namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<notas> notas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<notas>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<notas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<notas>()
                .Property(e => e.prioridad)
                .IsUnicode(false);
        }
    }
}
