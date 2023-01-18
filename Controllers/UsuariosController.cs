using CursoEntity.Datos;
using CursoEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEntity.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public UsuariosController(ApplicationDbContext context)
        {
            _contexto = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Usuario> listaUsuario = _contexto.Usuario.ToList();
            return View(listaUsuario);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
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
            var usuario = _contexto.Usuario.FirstOrDefault(c => c.Id == id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var usuario = _contexto.Usuario.FirstOrDefault(c => c.Id == id);
            _contexto.Usuario.Remove(usuario);
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle (int? id)
        {
            if(id == null)
            {
                return View();
            }
            var usuario = _contexto.Usuario.Include(d => d.DetalleUsuario).FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View();
        }

    }
}
