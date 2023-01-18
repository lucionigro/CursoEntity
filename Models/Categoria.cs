using System.ComponentModel.DataAnnotations;

namespace CursoEntity.Models
{
    public class Categoria
    {
        public int Categoria_Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public bool Activo { get; set; }
        public List<Articulo> Articulo { get; set; }
    }
}
