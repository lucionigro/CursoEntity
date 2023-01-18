using CursoEntity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEntity.ViewModels
{
    public class ArticuloCategoriaVM
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
