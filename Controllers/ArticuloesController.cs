using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoEntity.Datos;
using CursoEntity.Models;

namespace CursoEntity.Controllers
{
    public class ArticuloesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticuloesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articuloes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articulo.Include(a => a.Categoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articuloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articulo == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo
                .Include(a => a.Categoria)
                .FirstOrDefaultAsync(m => m.ArticuloID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articuloes/Create
        public IActionResult Create()
        {
            ViewData["Categoria_Id"] = new SelectList(_context.Categoria, "Categoria_Id", "Nombre");
            return View();
        }

        // POST: Articuloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticuloID,TituloArticulo,Descripcion,Calificacion,Fecha,Categoria_Id")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria_Id"] = new SelectList(_context.Categoria, "Categoria_Id", "Nombre", articulo.Categoria_Id);
            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articulo == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["Categoria_Id"] = new SelectList(_context.Categoria, "Categoria_Id", "Nombre", articulo.Categoria_Id);
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticuloID,TituloArticulo,Descripcion,Calificacion,Fecha,Categoria_Id")] Articulo articulo)
        {
            if (id != articulo.ArticuloID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.ArticuloID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria_Id"] = new SelectList(_context.Categoria, "Categoria_Id", "Nombre", articulo.Categoria_Id);
            return View(articulo);
        }

        // GET: Articuloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articulo == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo
                .Include(a => a.Categoria)
                .FirstOrDefaultAsync(m => m.ArticuloID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articulo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articulo'  is null.");
            }
            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulo.Remove(articulo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
          return _context.Articulo.Any(e => e.ArticuloID == id);
        }
    }
}
