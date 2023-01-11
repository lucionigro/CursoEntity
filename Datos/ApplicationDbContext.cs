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
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
