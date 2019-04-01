namespace WebApplicationApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.Serialization;

    [KnownType(typeof(Alimentos))]
    [KnownType(typeof(Calorias))]
    [KnownType(typeof(Usuarios))]
    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public DbSet<Alimentos> Alimentos { get; set; }
        public DbSet<Calorias> Calorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alimentos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            //modelBuilder.Entity<Alimentos>()
            //    .HasMany(e => e.Calorias1)
            //    .WithRequired(e => e.Alimentos)
            //    .HasForeignKey(e => e.codigoAlimento)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Calorias>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Calorias>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Calorias>()
                .Property(e => e.tipoComida)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.foto)
                .IsUnicode(false);

            //modelBuilder.Entity<Usuarios>()
            //    .HasMany(e => e.Calorias)
            //    .WithRequired(e => e.Usuarios)
            //    .WillCascadeOnDelete(false);
        }
    }
}
