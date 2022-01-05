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
    public class TesteController : Controller
    {
        private readonly TpCodeFirstDbContext _context;

        public TesteController(TpCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: Teste
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testes.ToListAsync());
        }

        // GET: Teste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testes = await _context.Testes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testes == null)
            {
                return NotFound();
            }

            return View(testes);
        }

        // GET: Teste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoTeste,NomeTeste,Resultado")] Testes testes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testes);
        }

        // GET: Teste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testes = await _context.Testes.FindAsync(id);
            if (testes == null)
            {
                return NotFound();
            }
            return View(testes);
        }

        // POST: Teste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoTeste,NomeTeste,Resultado")] Testes testes)
        {
            if (id != testes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestesExists(testes.Id))
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
            return View(testes);
        }

        // GET: Teste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testes = await _context.Testes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testes == null)
            {
                return NotFound();
            }

            return View(testes);
        }

        // POST: Teste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testes = await _context.Testes.FindAsync(id);
            _context.Testes.Remove(testes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestesExists(int id)
        {
            return _context.Testes.Any(e => e.Id == id);
        }
    }
}
