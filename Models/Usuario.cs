using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntity.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [EmailAddress(ErrorMessage ="Porfavor ingrese un mail correcto")]
        public string Email { get; set; }

        [ForeignKey("DetalleUsuario")]
        public int DetalleUsuario_ID { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
