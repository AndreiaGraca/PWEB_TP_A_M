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
    public class LocalizacaoController : Controller
    {
        private readonly TpCodeFirstDbContext _context;

        public LocalizacaoController(TpCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: Localizacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Localizacoes.ToListAsync());
        }

        // GET: Localizacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacoes = await _context.Localizacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizacoes == null)
            {
                return NotFound();
            }

            return View(localizacoes);
        }

        // GET: Localizacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localizacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local,Codigo_Postal")] Localizacoes localizacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localizacoes);
        }

        // GET: Localizacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacoes = await _context.Localizacoes.FindAsync(id);
            if (localizacoes == null)
            {
                return NotFound();
            }
            return View(localizacoes);
        }

        // POST: Localizacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local,Codigo_Postal")] Localizacoes localizacoes)
        {
            if (id != localizacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizacoesExists(localizacoes.Id))
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
            return View(localizacoes);
        }

        // GET: Localizacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacoes = await _context.Localizacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizacoes == null)
            {
                return NotFound();
            }

            return View(localizacoes);
        }

        // POST: Localizacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localizacoes = await _context.Localizacoes.FindAsync(id);
            _context.Localizacoes.Remove(localizacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizacoesExists(int id)
        {
            return _context.Localizacoes.Any(e => e.Id == id);
        }
    }
}
