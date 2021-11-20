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
    public class PinjamenController : Controller
    {
        private readonly db_perpusContext _context;

        public PinjamenController(db_perpusContext context)
        {
            _context = context;
        }

        // GET: Pinjamen
        public async Task<IActionResult> Index()
        {
            var db_perpusContext = _context.Pinjamen.Include(p => p.IdBukuNavigation).Include(p => p.IdNotaNavigation);
            return View(await db_perpusContext.ToListAsync());
        }

        // GET: Pinjamen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pinjaman = await _context.Pinjamen
                .Include(p => p.IdBukuNavigation)
                .Include(p => p.IdNotaNavigation)
                .FirstOrDefaultAsync(m => m.IdPinjaman == id);
            if (pinjaman == null)
            {
                return NotFound();
            }

            return View(pinjaman);
        }

        // GET: Pinjamen/Create
        public IActionResult Create()
        {
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "JudulBuku");
            ViewData["IdNota"] = new SelectList(_context.Nota, "IdNota", "IdNota");
            return View();
        }

        // POST: Pinjamen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPinjaman,IdNota,IdBuku,Jumlah")] Pinjaman pinjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pinjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "IdBuku", pinjaman.IdBuku);
            ViewData["IdNota"] = new SelectList(_context.Nota, "IdNota", "IdNota", pinjaman.IdNota);
            return View(pinjaman);
        }

        // GET: Pinjamen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pinjaman = await _context.Pinjamen.FindAsync(id);
            if (pinjaman == null)
            {
                return NotFound();
            }
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "JudulBuku", pinjaman.IdBuku);
            ViewData["IdNota"] = new SelectList(_context.Nota, "IdNota", "IdNota", pinjaman.IdNota);
            return View(pinjaman);
        }

        // POST: Pinjamen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPinjaman,IdNota,IdBuku,Jumlah")] Pinjaman pinjaman)
        {
            if (id != pinjaman.IdPinjaman)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pinjaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PinjamanExists(pinjaman.IdPinjaman))
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
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "IdBuku", pinjaman.IdBuku);
            ViewData["IdNota"] = new SelectList(_context.Nota, "IdNota", "IdNota", pinjaman.IdNota);
            return View(pinjaman);
        }

        // GET: Pinjamen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pinjaman = await _context.Pinjamen
                .Include(p => p.IdBukuNavigation)
                .Include(p => p.IdNotaNavigation)
                .FirstOrDefaultAsync(m => m.IdPinjaman == id);
            if (pinjaman == null)
            {
                return NotFound();
            }

            return View(pinjaman);
        }

        // POST: Pinjamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pinjaman = await _context.Pinjamen.FindAsync(id);
            _context.Pinjamen.Remove(pinjaman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PinjamanExists(int id)
        {
            return _context.Pinjamen.Any(e => e.IdPinjaman == id);
        }
    }
}
