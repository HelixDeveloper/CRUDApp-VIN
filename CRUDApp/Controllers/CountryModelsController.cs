using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDApp.Models.Database;

namespace CRUDApp.Controllers
{
    public class CountryModelsController : Controller
    {
        private readonly LocationDbContext _context;

        public CountryModelsController(LocationDbContext context)
        {
            _context = context;
        }

        // GET: CountryModels
        public async Task<IActionResult> Index()
        {
              return _context.Countries != null ? 
                          View(await _context.Countries.ToListAsync()) :
                          Problem("Entity set 'LocationDbContext.Countries'  is null.");
        }

        // GET: CountryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // GET: CountryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,CountryName,CountryCode")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryModel);
        }

        // GET: CountryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries.FindAsync(id);
            if (countryModel == null)
            {
                return NotFound();
            }
            return View(countryModel);
        }

        // POST: CountryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryId,CountryName,CountryCode")] CountryModel countryModel)
        {
            if (id != countryModel.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryModelExists(countryModel.CountryId))
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
            return View(countryModel);
        }

        // GET: CountryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // POST: CountryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Countries == null)
            {
                return Problem("Entity set 'LocationDbContext.Countries'  is null.");
            }
            var countryModel = await _context.Countries.FindAsync(id);
            if (countryModel != null)
            {
                _context.Countries.Remove(countryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryModelExists(int id)
        {
          return (_context.Countries?.Any(e => e.CountryId == id)).GetValueOrDefault();
        }
    }
}
