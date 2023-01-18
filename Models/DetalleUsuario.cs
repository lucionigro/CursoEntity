using System.ComponentModel.DataAnnotations;

namespace CursoEntity.Models
{
    public class DetalleUsuario
    {
        [Key]
        public int DetalleUsuario_ID { get; set; }
        [Required]
        [StringLength(25)]
        public string Cedula { get; set; }
        [StringLength(50)]
        public string Deporte { get; set; }
        [StringLength(25)]
        public string Mascota { get; set; }
        public Usuario Usuario { get; set; }
    }
}
