using System.ComponentModel.DataAnnotations;

namespace CursoEntity.Models
{
    public class Etiqueta
    {
        public int Etiqueta_ID { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<ArticuloEtiqueta> ArticuloEtiqueta { get; set; }
    }
}
