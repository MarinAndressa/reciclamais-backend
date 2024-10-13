using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reciclamais_backend.Models;

namespace reciclamais_backend.Controllers
{
    [Authorize]
    public class NoticiasController : Controller
    {
        private readonly AppDbContext _context;
        
        public NoticiasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Noticias.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Noticias.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Noticia noticia)
        {
            if(id != noticia.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Noticias.Update(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if(dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DetailsConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Noticias.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Noticias.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
