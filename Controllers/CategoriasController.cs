using CursoEntity.Datos;
using CursoEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEntity.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public CategoriasController(ApplicationDbContext context)
        {
            _contexto = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Categoria> listaCategoria = _contexto.Categoria.ToList();
            return View(listaCategoria);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _contexto.Categoria.Add(categoria);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var categoria = _contexto.Categoria.FirstOrDefault(c => c.Categoria_Id== id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar (Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contexto.Categoria.Update(categoria);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Eliminar (int? id)
        {
            var categoria = _contexto.Categoria.FirstOrDefault(c => c.Categoria_Id == id);
            _contexto.Categoria.Remove(categoria);
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
