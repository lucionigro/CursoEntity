using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntity.Models
{
    //Modifica el nombre de la tabla en el SQL Server
    [Table("Articulo")]
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
        [Required(ErrorMessage = "Es un campo obligatorio")]
        public string TituloArticulo { get; set; }
        [StringLength(500, ErrorMessage ="La descripcion no debe superar los 500 caracteres")]
        public string Descripcion { get; set; }
        //Cambia como se ve en el frontend 
        [Display(Name = "Fecha de entrega del articulo")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        //Al ingresar NotMapped, esta instancia de codigo no va a mappearse a la BD
        [NotMapped]
        public string NoMapea { get; set; }
        //Define el rango de valores minimo y maximo
        [Range(0.1, 5.0)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText ="[NULL]")]
        public double Calificacion { get; set; }

        [ForeignKey("Categoria")]
        public int Categoria_Id { get; set; }
        public Categoria Categoria { get; set; }

        //Para relacion muchos a muchos
        public ICollection<ArticuloEtiqueta> ArticuloEtiqueta { get; set; }
       
    }
}
