using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWEB_TP_A_M.Data;
using PWEB_TP_A_M.Models;

namespace PWEB_TP_A_M.Controllers
{
    public class GestorController : Controller
    {
        private readonly TpCodeFirstDbContext _context;

        public GestorController(TpCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: Gestor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gestores.ToListAsync());
        }

        // GET: Gestor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestores = await _context.Gestores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestores == null)
            {
                return NotFound();
            }

            return View(gestores);
        }

        // GET: Gestor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Centro,CentroId")] Gestores gestores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestores);
        }

        // GET: Gestor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestores = await _context.Gestores.FindAsync(id);
            if (gestores == null)
            {
                return NotFound();
            }
            return View(gestores);
        }

        // POST: Gestor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Centro,CentroId")] Gestores gestores)
        {
            if (id != gestores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestoresExists(gestores.Id))
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
            return View(gestores);
        }

        // GET: Gestor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestores = await _context.Gestores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestores == null)
            {
                return NotFound();
            }

            return View(gestores);
        }

        // POST: Gestor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestores = await _context.Gestores.FindAsync(id);
            _context.Gestores.Remove(gestores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestoresExists(int id)
        {
            return _context.Gestores.Any(e => e.Id == id);
        }
    }
}
