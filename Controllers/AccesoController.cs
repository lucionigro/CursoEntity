using CursoEntity.Datos;
using Microsoft.AspNetCore.Mvc;
using CursoEntity.Models;

namespace CursoEntity.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccesoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Nombre)
        {
            try
            {
                var oUser = (from d in _context.Usuario
                             where d.Email == Email && d.Nombre == Nombre.Trim()
                             select d).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Nombre o Email incorrecto";
                    return View();
                }
                return RedirectToAction("Index", "Home");
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
