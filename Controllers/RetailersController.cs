using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barna_Valentina_Proiect_Pies.Data;
using Barna_Valentina_Proiect_Pies.Models;
using Barna_Valentina_Proiect_Pies.Models.LibraryViewModels;

namespace Barna_Valentina_Proiect_Pies.Controllers
{
    public class RetailersController : Controller
    {
        private readonly PieContext _context;

        public RetailersController(PieContext context)
        {
            _context = context;
        }

        // GET: Retailers
        public async Task<IActionResult> Index(int? id, int? pieID)
        {
            var viewModel = new RetailerIndexData();
            viewModel.Retailers = await _context.Retailers
        .Include(i => i.RetailedPies)
 .ThenInclude(i => i.Pie)
 .ThenInclude(i => i.Orders)
 .ThenInclude(i => i.Customer)
 .AsNoTracking()
 .OrderBy(i => i.RetailerName)
 .ToListAsync();
            if (id != null)
            {
                ViewData["RetailerID"] = id.Value;
                Retailer retailer = viewModel.Retailers.Where(
                i => i.ID == id.Value).Single();
                viewModel.Pies = retailer.RetailedPies.Select(s => s.Pie);
            }
            if (pieID != null)
            {
                ViewData["RetailerID"] =pieID.Value;
                viewModel.Orders = viewModel.Pies.Where(
                x => x.ID == pieID).Single().Orders;
            }
            return View(viewModel);
        }

        // GET: Retailers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = await _context.Retailers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (retailer == null)
            {
                return NotFound();
            }

            return View(retailer);
        }

        // GET: Retailers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retailers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RetailerName,Adress")] Retailer retailer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retailer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retailer);
        }

        // GET: Retailers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = await _context.Retailers.FindAsync(id);
            if (retailer == null)
            {
                return NotFound();
            }
            return View(retailer);
        }

        // POST: Retailers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RetailerName,Adress")] Retailer retailer)
        {
            if (id != retailer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retailer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetailerExists(retailer.ID))
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
            return View(retailer);
        }

        // GET: Retailers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = await _context.Retailers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (retailer == null)
            {
                return NotFound();
            }

            return View(retailer);
        }

        // POST: Retailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retailer = await _context.Retailers.FindAsync(id);
            _context.Retailers.Remove(retailer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetailerExists(int id)
        {
            return _context.Retailers.Any(e => e.ID == id);
        }
    }
}
