﻿using System;
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
    public class LicenseTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicenseTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LicenseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LicenseType.ToListAsync());
        }

        // GET: LicenseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseType = await _context.LicenseType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licenseType == null)
            {
                return NotFound();
            }

            return View(licenseType);
        }

        // GET: LicenseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LicenseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] LicenseType licenseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(licenseType);
        }

        // GET: LicenseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseType = await _context.LicenseType.SingleOrDefaultAsync(m => m.Id == id);
            if (licenseType == null)
            {
                return NotFound();
            }
            return View(licenseType);
        }

        // POST: LicenseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] LicenseType licenseType)
        {
            if (id != licenseType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseTypeExists(licenseType.Id))
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
            return View(licenseType);
        }

        // GET: LicenseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseType = await _context.LicenseType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licenseType == null)
            {
                return NotFound();
            }

            return View(licenseType);
        }

        // POST: LicenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenseType = await _context.LicenseType.SingleOrDefaultAsync(m => m.Id == id);
            _context.LicenseType.Remove(licenseType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenseTypeExists(int id)
        {
            return _context.LicenseType.Any(e => e.Id == id);
        }
    }
}
