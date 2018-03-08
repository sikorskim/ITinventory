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
    public class LicenseDevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicenseDevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LicenseDevices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LicenseDevice.Include(l => l.Device).Include(l => l.License);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LicenseDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseDevice = await _context.LicenseDevice
                .Include(l => l.Device)
                .Include(l => l.License)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licenseDevice == null)
            {
                return NotFound();
            }

            return View(licenseDevice);
        }

        // GET: LicenseDevices/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.Device, "Id", "Name");
            ViewData["LicenseId"] = new SelectList(_context.License, "Id", "Name");
            return View();
        }

        // POST: LicenseDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicenseId,DeviceId")] LicenseDevice licenseDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenseDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.Device, "Id", "Id", licenseDevice.DeviceId);
            ViewData["LicenseId"] = new SelectList(_context.License, "Id", "Id", licenseDevice.LicenseId);
            return View(licenseDevice);
        }

        // GET: LicenseDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseDevice = await _context.LicenseDevice.SingleOrDefaultAsync(m => m.Id == id);
            if (licenseDevice == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.Device, "Id", "Id", licenseDevice.DeviceId);
            ViewData["LicenseId"] = new SelectList(_context.License, "Id", "Id", licenseDevice.LicenseId);
            return View(licenseDevice);
        }

        // POST: LicenseDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicenseId,DeviceId")] LicenseDevice licenseDevice)
        {
            if (id != licenseDevice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenseDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseDeviceExists(licenseDevice.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.Device, "Id", "Id", licenseDevice.DeviceId);
            ViewData["LicenseId"] = new SelectList(_context.License, "Id", "Id", licenseDevice.LicenseId);
            return View(licenseDevice);
        }

        // GET: LicenseDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseDevice = await _context.LicenseDevice
                .Include(l => l.Device)
                .Include(l => l.License)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licenseDevice == null)
            {
                return NotFound();
            }

            return View(licenseDevice);
        }

        // POST: LicenseDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenseDevice = await _context.LicenseDevice.SingleOrDefaultAsync(m => m.Id == id);
            _context.LicenseDevice.Remove(licenseDevice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenseDeviceExists(int id)
        {
            return _context.LicenseDevice.Any(e => e.Id == id);
        }
    }
}
