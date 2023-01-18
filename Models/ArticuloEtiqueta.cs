using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntity.Models
{
    public class ArticuloEtiqueta
        //Este modelo fue creado para realizar una relacion muchos a muchos en la BD entre Articulos y Etiqueta
    {
        public int ArticuloID { get; set; }
        public int Etiqueta_ID { get; set; }
        public Articulo Articulo { get; set; }
        public Etiqueta Etiqueta { get;set; }
    }
}
