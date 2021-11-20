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
    public class BukuController : Controller
    {
        private readonly db_perpusContext _context;

        public BukuController(db_perpusContext context)
        {
            _context = context;
        }

        // GET: Buku
        public async Task<IActionResult> Index()
        {
            var db_perpusContext = _context.Bukus.Include(b => b.IdKategoriNavigation);
            return View(await db_perpusContext.ToListAsync());
        }

        // GET: Buku/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Bukus
                .Include(b => b.IdKategoriNavigation)
                .FirstOrDefaultAsync(m => m.IdBuku == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        // GET: Buku/Create
        public IActionResult Create()
        {
            ViewData["IdKategori"] = new SelectList(_context.Kategoris, "IdKategori", "NamaKategori");
            return View();
        }

        // POST: Buku/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBuku,JudulBuku,Harga,Deskripsi,IdKategori,GambarBuku")] Buku buku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKategori"] = new SelectList(_context.Kategoris, "IdKategori", "IdKategori", buku.IdKategori);
            return View(buku);
        }

        // GET: Buku/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Bukus.FindAsync(id);
            if (buku == null)
            {
                return NotFound();
            }
            ViewData["IdKategori"] = new SelectList(_context.Kategoris, "IdKategori", "NamaKategori", buku.IdKategori);
            return View(buku);
        }

        // POST: Buku/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBuku,JudulBuku,Harga,Deskripsi,IdKategori,GambarBuku")] Buku buku)
        {
            if (id != buku.IdBuku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BukuExists(buku.IdBuku))
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
            ViewData["IdKategori"] = new SelectList(_context.Kategoris, "IdKategori", "IdKategori", buku.IdKategori);
            return View(buku);
        }

        // GET: Buku/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Bukus
                .Include(b => b.IdKategoriNavigation)
                .FirstOrDefaultAsync(m => m.IdBuku == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        // POST: Buku/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buku = await _context.Bukus.FindAsync(id);
            _context.Bukus.Remove(buku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BukuExists(int id)
        {
            return _context.Bukus.Any(e => e.IdBuku == id);
        }
    }
}
