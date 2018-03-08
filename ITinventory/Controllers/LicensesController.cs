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
    public class LicensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Licenses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.License.Include(l => l.LicenseType).Include(l => l.Software);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Licenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.License
                .Include(l => l.LicenseType)
                .Include(l => l.Software)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (license == null)
            {
                return NotFound();
            }

            return View(license);
        }

        // GET: Licenses/Create
        public IActionResult Create()
        {
            ViewData["LicenseTypeId"] = new SelectList(_context.LicenseType, "Id", "Name");
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Name");
            return View();
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicenseTypeId,SoftwareId,Quantity,Used,ValidFrom,ValidTo")] License license)
        {
            if (ModelState.IsValid)
            {
                _context.Add(license);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LicenseTypeId"] = new SelectList(_context.LicenseType, "Id", "Name", license.LicenseTypeId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Name", license.SoftwareId);
            return View(license);
        }

        // GET: Licenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.License.SingleOrDefaultAsync(m => m.Id == id);
            if (license == null)
            {
                return NotFound();
            }
            ViewData["LicenseTypeId"] = new SelectList(_context.LicenseType, "Id", "Id", license.LicenseTypeId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Id", license.SoftwareId);
            return View(license);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicenseTypeId,SoftwareId,Quantity,Used,ValidFrom,ValidTo")] License license)
        {
            if (id != license.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(license);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseExists(license.Id))
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
            ViewData["LicenseTypeId"] = new SelectList(_context.LicenseType, "Id", "Id", license.LicenseTypeId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Id", license.SoftwareId);
            return View(license);
        }

        // GET: Licenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.License
                .Include(l => l.LicenseType)
                .Include(l => l.Software)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (license == null)
            {
                return NotFound();
            }

            return View(license);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var license = await _context.License.SingleOrDefaultAsync(m => m.Id == id);
            _context.License.Remove(license);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenseExists(int id)
        {
            return _context.License.Any(e => e.Id == id);
        }
    }
}
