using System.ComponentModel.DataAnnotations;

namespace CursoEntity.Models
{
    public class Categoria
    {

        [Key]
        public int Categoria_Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Articulo> Articulo { get; set; }
    }
}
