using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barna_Valentina_Proiect_Pies.Data;
using Barna_Valentina_Proiect_Pies.Models;

namespace Barna_Valentina_Proiect_Pies.Controllers
{
    public class PiesController : Controller
    {
        private readonly PieContext _context;

        public PiesController(PieContext context)
        {
            _context = context;
        }

        // GET: Pies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pies.ToListAsync());
        }

        // GET: Pies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // GET: Pies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortDescription,Price")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pie);
        }

        // GET: Pies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies.FindAsync(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }

        // POST: Pies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortDescription,Price")] Pie pie)
        {
            if (id != pie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieExists(pie.ID))
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
            return View(pie);
        }

        // GET: Pies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // POST: Pies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pie = await _context.Pies.FindAsync(id);
            _context.Pies.Remove(pie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieExists(int id)
        {
            return _context.Pies.Any(e => e.ID == id);
        }
    }
}
