using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntity.Models
{
    //Modifica el nombre de la tabla en el SQL Server
    [Table("TBL_Articulo")]
    public class Articulo
    {
        //Siempre la PK terminar con un ID/Id y Entity reconoce que es una PK Identity
        [Key]
        //Atributo [Key] define la PK en caso de no tener un ID en el nombre de la columna
        public int ArticuloID { get; set; }
        //Cambia el nombre de la columna sin importar como se define en la Class
        [Column("Titulo")]
        //Define el maximo de caracteres (Importante para no ocupar memoria extra)
        [MaxLength(50)]
        //Importante 
        [Required(ErrorMessage ="Es un campo obligatorio")]
        public string TituloArticulo { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        //Cambia como se ve en el frontend 
        [Display(Name="Fecha de entrega del articulo")]
        public string Fecha { get; set; }
        //Al ingresar NotMapped, esta instancia de codigo no va a mappearse a la BD
        [NotMapped]
        public string NoMapea { get; set; }
        //Define el rango de valores minimo y maximo
        [Range(0.1, 5.0)]
        public double Calificacion { get; set; }
    }
}
