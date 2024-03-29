﻿using System;
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
    public class AnaliseController : Controller
    {
        private readonly TpCodeFirstDbContext _context;

        public AnaliseController(TpCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: Analises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Analises.ToListAsync());
        }

        // GET: Analises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analises = await _context.Analises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analises == null)
            {
                return NotFound();
            }

            return View(analises);
        }

        // GET: Analises/Create
        public IActionResult Create()
        {
            ViewData["AnalisesId"] = new SelectList(_context.Analises, "Id", "Tipo");
            return View();
        }

        // POST: Analises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoAnalise,NomeAnalise,Resultados")] Analises analises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analises);
        }

        // GET: Analises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analises = await _context.Analises.FindAsync(id);
            if (analises == null)
            {
                return NotFound();
            }
            return View(analises);
        }

        // POST: Analises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoAnalise,NomeAnalise,Resultados")] Analises analises)
        {
            if (id != analises.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalisesExists(analises.Id))
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
            return View(analises);
        }

        // GET: Analises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analises = await _context.Analises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analises == null)
            {
                return NotFound();
            }

            return View(analises);
        }

        // POST: Analises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analises = await _context.Analises.FindAsync(id);
            _context.Analises.Remove(analises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalisesExists(int id)
        {
            return _context.Analises.Any(e => e.Id == id);
        }
    }
}
