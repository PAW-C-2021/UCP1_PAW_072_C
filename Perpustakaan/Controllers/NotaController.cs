using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class NotaController : Controller
    {
        private readonly db_perpusContext _context;

        public NotaController(db_perpusContext context)
        {
            _context = context;
        }

        // GET: Nota
        public async Task<IActionResult> Index()
        {
            var db_perpusContext = _context.Nota.Include(n => n.IdAdminNavigation).Include(n => n.IdPeminjamNavigation);
            return View(await db_perpusContext.ToListAsync());
        }

        // GET: Nota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.IdAdminNavigation)
                .Include(n => n.IdPeminjamNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // GET: Nota/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "NamaAdmin");
            ViewData["IdPeminjam"] = new SelectList(_context.Peminjams, "IdPeminjam", "Nama");
            return View();
        }

        // POST: Nota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNota,IdPeminjam,IdAdmin,TglDeadline,TglPinjam,TglKembali,Denda,Status")] Notum notum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", notum.IdAdmin);
            ViewData["IdPeminjam"] = new SelectList(_context.Peminjams, "IdPeminjam", "IdPeminjam", notum.IdPeminjam);
            return View(notum);
        }

        // GET: Nota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota.FindAsync(id);
            if (notum == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "NamaAdmin", notum.IdAdmin);
            ViewData["IdPeminjam"] = new SelectList(_context.Peminjams, "IdPeminjam", "Nama", notum.IdPeminjam);
            return View(notum);
        }

        // POST: Nota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,IdPeminjam,IdAdmin,TglDeadline,TglPinjam,TglKembali,Denda,Status")] Notum notum)
        {
            if (id != notum.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotumExists(notum.IdNota))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", notum.IdAdmin);
            ViewData["IdPeminjam"] = new SelectList(_context.Peminjams, "IdPeminjam", "IdPeminjam", notum.IdPeminjam);
            return View(notum);
        }

        // GET: Nota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.IdAdminNavigation)
                .Include(n => n.IdPeminjamNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notum = await _context.Nota.FindAsync(id);
            _context.Nota.Remove(notum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotumExists(int id)
        {
            return _context.Nota.Any(e => e.IdNota == id);
        }
    }
}
