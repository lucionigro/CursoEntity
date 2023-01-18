using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntity.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }     
        [EmailAddress(ErrorMessage ="Porfavor ingrese un mail correcto")]
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }

        public int? DetalleUsuario_ID { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
