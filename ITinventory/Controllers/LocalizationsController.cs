using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITinventory.Data;
using ITinventory.Models;

namespace ITinventory.Controllers
{
    public class LocalizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Localizations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Localization.ToListAsync());
        }

        // GET: Localizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization
                .SingleOrDefaultAsync(m => m.Id == id);
            if (localization == null)
            {
                return NotFound();
            }

            return View(localization);
        }

        // GET: Localizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentId,Name")] Localization localization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localization);
        }

        // GET: Localizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization.SingleOrDefaultAsync(m => m.Id == id);
            if (localization == null)
            {
                return NotFound();
            }
            return View(localization);
        }

        // POST: Localizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentId,Name")] Localization localization)
        {
            if (id != localization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizationExists(localization.Id))
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
            return View(localization);
        }

        // GET: Localizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization
                .SingleOrDefaultAsync(m => m.Id == id);
            if (localization == null)
            {
                return NotFound();
            }

            return View(localization);
        }

        // POST: Localizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localization = await _context.Localization.SingleOrDefaultAsync(m => m.Id == id);
            _context.Localization.Remove(localization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizationExists(int id)
        {
            return _context.Localization.Any(e => e.Id == id);
        }
    }
}
