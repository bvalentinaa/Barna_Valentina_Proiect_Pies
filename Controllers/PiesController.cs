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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var pies = from b in _context.Pies
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                pies = pies.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc"
            :
                    pies = pies.OrderByDescending(b => b.Name);
            break;
                case "Price":
                    pies = pies.OrderBy(b => b.Price);
            break;
                case "price_desc":
                    pies = pies.OrderByDescending(b => b.Price);
            break;
            default:
                    pies = pies.OrderBy(b => b.Name);
            break;
        }
        int pageSize = 2;
            return View(await PaginatedList<Pie>.CreateAsync(pies.AsNoTracking(), pageNumber ??1, pageSize));
        }

        // GET: Pies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
               .Include(s => s.Orders)
               .ThenInclude(e => e.Customer)
               .AsNoTracking()
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
        public async Task<IActionResult> Create([Bind("Name,ShortDescription,Price")] Pie pie)
        {try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(pie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            } catch (DbUpdateException /* ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes." + "Try again, and if the problem persists ");
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
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieToUpdate = await _context.Pies.FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Pie>(
                pieToUpdate,
                "",
                s => s.Name, s => s.ShortDescription, s => s.Price))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes." + "Try again, and if the problem persists");
                }
            }
            return View(pieToUpdate);
        }

        // GET: Pies/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pie == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again";
            }

            return View(pie);
        }

        // POST: Pies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pie = await _context.Pies.FindAsync(id);
            if (pie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Pies.Remove(pie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } catch(DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool PieExists(int id)
        {
            return _context.Pies.Any(e => e.ID == id);
        }
    }
}
