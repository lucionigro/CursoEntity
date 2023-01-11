using Microsoft.EntityFrameworkCore;

namespace CursoEntity.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) :base(opciones)
        {

        }

        // Escribir modelos

    }
}
