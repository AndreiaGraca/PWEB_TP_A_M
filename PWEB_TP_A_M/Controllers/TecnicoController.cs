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
    public class TecnicoController : Controller
    {
        private readonly TpCodeFirstDbContext _context;

        public TecnicoController(TpCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: Tecnico
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tecnicos.ToListAsync());
        }

        // GET: Tecnico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return View(tecnicos);
        }

        // GET: Tecnico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Especialidade,IdAgendamento")] Tecnicos tecnicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnicos);
        }

        // GET: Tecnico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos.FindAsync(id);
            if (tecnicos == null)
            {
                return NotFound();
            }
            return View(tecnicos);
        }

        // POST: Tecnico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Especialidade,IdAgendamento")] Tecnicos tecnicos)
        {
            if (id != tecnicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicosExists(tecnicos.Id))
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
            return View(tecnicos);
        }

        // GET: Tecnico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return View(tecnicos);
        }

        // POST: Tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnicos = await _context.Tecnicos.FindAsync(id);
            _context.Tecnicos.Remove(tecnicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicosExists(int id)
        {
            return _context.Tecnicos.Any(e => e.Id == id);
        }
    }
}
