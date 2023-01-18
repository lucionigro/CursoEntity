using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntity.Models
{
    public class ArticuloEtiqueta
        //Este modelo fue creado para realizar una relacion muchos a muchos en la BD entre Articulos y Etiqueta
    {
        [ForeignKey("Articulo")]
        public int ArticuloID { get; set; }
        [ForeignKey("Etiqueta")]
        public int Etiqueta_ID { get; set; }

        public Articulo Articulo { get; set; }
        public Etiqueta Etiqueta { get;set; }
    }
}
