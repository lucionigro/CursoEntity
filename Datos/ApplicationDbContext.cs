using CursoEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntity.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) :base(opciones)
        {

        }
        // Escribir modelos
        //Cuando crear migraciones (buenas practicas)
        //1- Cuando se crea una nueva clase == tabla en la DB
        //2- Cuando agregue una nueva propiedad (crear un campo nuevo en la base de datos)
        //3- Cuando modifique un valor de campo en la clase (modificar un campo en BD)

        //Como crear migraciones:
        //En la terminal add-migration "nombre de migracion"
        //Despues update-database y listo
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuario { get; set; }
        public DbSet<Etiqueta> Etiqueta { get; set; }


        //Para la creacion de la tabla intermedia de la relacion muchos a muchos ArticuloEtiqueta

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new {ae.Etiqueta_ID, ae.ArticuloID});

            //Fluent API para Categoria
            modelBuilder.Entity<Categoria>().HasKey(c => c.Categoria_Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<Categoria>().Property(c => c.FechaCreacion).HasColumnType("date");

            //Fluent API para Articulo
            modelBuilder.Entity<Articulo>().HasKey(c => c.ArticuloID);
            modelBuilder.Entity<Articulo>().Property(c => c.TituloArticulo).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Articulo>().Property(c => c.Descripcion).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Articulo>().Property(c => c.Fecha).HasColumnType("date");
            modelBuilder.Entity<Articulo>().ToTable("Tbl_Articulo");
            modelBuilder.Entity<Articulo>().Property(c => c.TituloArticulo).HasColumnName("Titulo");


            //Fluent API para Usuario
            modelBuilder.Entity<Usuario>().HasKey(c => c.Id);
            modelBuilder.Entity<Usuario>().Ignore(c => c.Edad);


            //Fluent API para Detallesuario
            modelBuilder.Entity<DetalleUsuario>().HasKey(c => c.DetalleUsuario_ID);
            modelBuilder.Entity<DetalleUsuario>().Property(c => c.Cedula).IsRequired();
            

            //Fluent API para Etiqueta
            modelBuilder.Entity<Etiqueta>().HasKey(c => c.Etiqueta_ID);
            modelBuilder.Entity<Etiqueta>().Property(c => c.Fecha).HasColumnType("date");

            //Fluent API relacion uno a uno (Usuario y DetalleUsuario)
            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.DetalleUsuario)
                .WithOne(c => c.Usuario).HasForeignKey<Usuario>("DetalleUsuario_ID");


            //Fluent API relacion uno a muchos (Categoria y Articulo)
            modelBuilder.Entity<Articulo>()
                .HasOne(c => c.Categoria)
                .WithMany(c => c.Articulo).HasForeignKey(c => c.Categoria_Id);

            //Fluent API relacion muchos a muchos (Articulo y Etiqueta)
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new {ae.Etiqueta_ID, ae.ArticuloID});
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasOne(c => c.Articulo)
                .WithMany(c => c.ArticuloEtiqueta).HasForeignKey(c => c.ArticuloID);
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasOne(c => c.Etiqueta)
                .WithMany(c => c.ArticuloEtiqueta).HasForeignKey(c => c.Etiqueta_ID);



            base.OnModelCreating(modelBuilder);
        }

    }
}
