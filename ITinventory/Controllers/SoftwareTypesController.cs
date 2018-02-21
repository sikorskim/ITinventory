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
    public class SoftwareTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoftwareTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SoftwareTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoftwareType.ToListAsync());
        }

        // GET: SoftwareTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareType = await _context.SoftwareType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (softwareType == null)
            {
                return NotFound();
            }

            return View(softwareType);
        }

        // GET: SoftwareTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoftwareTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SoftwareType softwareType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softwareType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(softwareType);
        }

        // GET: SoftwareTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareType = await _context.SoftwareType.SingleOrDefaultAsync(m => m.Id == id);
            if (softwareType == null)
            {
                return NotFound();
            }
            return View(softwareType);
        }

        // POST: SoftwareTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SoftwareType softwareType)
        {
            if (id != softwareType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softwareType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareTypeExists(softwareType.Id))
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
            return View(softwareType);
        }

        // GET: SoftwareTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareType = await _context.SoftwareType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (softwareType == null)
            {
                return NotFound();
            }

            return View(softwareType);
        }

        // POST: SoftwareTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softwareType = await _context.SoftwareType.SingleOrDefaultAsync(m => m.Id == id);
            _context.SoftwareType.Remove(softwareType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareTypeExists(int id)
        {
            return _context.SoftwareType.Any(e => e.Id == id);
        }
    }
}
