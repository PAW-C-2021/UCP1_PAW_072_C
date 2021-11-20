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
    public class PeminjamsController : Controller
    {
        private readonly db_perpusContext _context;

        public PeminjamsController(db_perpusContext context)
        {
            _context = context;
        }

        // GET: Peminjams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peminjams.ToListAsync());
        }

        // GET: Peminjams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjam = await _context.Peminjams
                .FirstOrDefaultAsync(m => m.IdPeminjam == id);
            if (peminjam == null)
            {
                return NotFound();
            }

            return View(peminjam);
        }

        // GET: Peminjams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peminjams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeminjam,Nama,Alamat,Username,Password,Email")] Peminjam peminjam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peminjam);
        }

        // GET: Peminjams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjam = await _context.Peminjams.FindAsync(id);
            if (peminjam == null)
            {
                return NotFound();
            }
            return View(peminjam);
        }

        // POST: Peminjams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeminjam,Nama,Alamat,Username,Password,Email")] Peminjam peminjam)
        {
            if (id != peminjam.IdPeminjam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peminjam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeminjamExists(peminjam.IdPeminjam))
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
            return View(peminjam);
        }

        // GET: Peminjams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjam = await _context.Peminjams
                .FirstOrDefaultAsync(m => m.IdPeminjam == id);
            if (peminjam == null)
            {
                return NotFound();
            }

            return View(peminjam);
        }

        // POST: Peminjams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peminjam = await _context.Peminjams.FindAsync(id);
            _context.Peminjams.Remove(peminjam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeminjamExists(int id)
        {
            return _context.Peminjams.Any(e => e.IdPeminjam == id);
        }
    }
}
