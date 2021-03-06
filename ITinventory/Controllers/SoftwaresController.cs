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
    public class SoftwaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoftwaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Softwares
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Software.Include(s => s.Manufacturer).Include(s => s.SoftwareType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Softwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .Include(s => s.Manufacturer)
                .Include(s => s.SoftwareType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // GET: Softwares/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name");
            ViewData["SoftwareTypeId"] = new SelectList(_context.SoftwareType, "Id", "Name");
            return View();
        }

        // POST: Softwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufacturerId,SoftwareTypeId,Name")] Software software)
        {
            if (ModelState.IsValid)
            {
                _context.Add(software);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", software.ManufacturerId);
            ViewData["SoftwareTypeId"] = new SelectList(_context.SoftwareType, "Id", "Name", software.SoftwareTypeId);
            return View(software);
        }

        // GET: Softwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software.SingleOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", software.ManufacturerId);
            ViewData["SoftwareTypeId"] = new SelectList(_context.SoftwareType, "Id", "Name", software.SoftwareTypeId);
            return View(software);
        }

        // POST: Softwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerId,SoftwareTypeId,Name")] Software software)
        {
            if (id != software.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.Id))
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
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", software.ManufacturerId);
            ViewData["SoftwareTypeId"] = new SelectList(_context.SoftwareType, "Id", "Name", software.SoftwareTypeId);
            return View(software);
        }

        // GET: Softwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .Include(s => s.Manufacturer)
                .Include(s => s.SoftwareType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var software = await _context.Software.SingleOrDefaultAsync(m => m.Id == id);
            _context.Software.Remove(software);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(int id)
        {
            return _context.Software.Any(e => e.Id == id);
        }
    }
}
