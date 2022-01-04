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
    public class CentroTesteController : Controller
    {
        private readonly TpCodeFirstDbContext _context;

        public CentroTesteController(TpCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: CentroTeste
        public async Task<IActionResult> Index()
        {
            var tpCodeFirstDbContext = _context.CentroTeste.Include(c => c.Analises);
            return View(await tpCodeFirstDbContext.ToListAsync());
        }

        // GET: CentroTeste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTeste = await _context.CentroTeste
                .Include(c => c.Analises)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroTeste == null)
            {
                return NotFound();
            }

            return View(centroTeste);
        }

        // GET: CentroTeste/Create
        public IActionResult Create()
        {
            ViewData["AnalisesId"] = new SelectList(_context.Analises, "Id", "Tipo");
            return View();
        }

        // POST: CentroTeste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Vagas,Localidade,Horario,LimTestes,Tecnico,AnalisesId,LocalidadeId,TecnicosId")] CentroTeste centroTeste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroTeste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnalisesId"] = new SelectList(_context.Analises, "Id", "Id", centroTeste.AnalisesId);
            return View(centroTeste);
        }

        // GET: CentroTeste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTeste = await _context.CentroTeste.FindAsync(id);
            if (centroTeste == null)
            {
                return NotFound();
            }
            ViewData["AnalisesId"] = new SelectList(_context.Analises, "Id", "Id", centroTeste.AnalisesId);
            return View(centroTeste);
        }

        // POST: CentroTeste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Vagas,Localidade,Horario,LimTestes,Tecnico,AnalisesId,LocalidadeId,TecnicosId")] CentroTeste centroTeste)
        {
            if (id != centroTeste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroTeste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroTesteExists(centroTeste.Id))
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
            ViewData["AnalisesId"] = new SelectList(_context.Analises, "Id", "Id", centroTeste.AnalisesId);
            return View(centroTeste);
        }

        // GET: CentroTeste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTeste = await _context.CentroTeste
                .Include(c => c.Analises)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroTeste == null)
            {
                return NotFound();
            }

            return View(centroTeste);
        }

        // POST: CentroTeste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroTeste = await _context.CentroTeste.FindAsync(id);
            _context.CentroTeste.Remove(centroTeste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroTesteExists(int id)
        {
            return _context.CentroTeste.Any(e => e.Id == id);
        }
    }
}
