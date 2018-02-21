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
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Device.Include(d => d.DeviceModel).Include(d => d.Invoice).Include(d => d.Localization).Include(d => d.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.DeviceModel)
                .Include(d => d.Invoice)
                .Include(d => d.Localization)
                .Include(d => d.Status)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Id");
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "Id");
            ViewData["LocalizationId"] = new SelectList(_context.Localization, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,StatusId,UserId,Name,InvoiceId,LocalizationId")] Device device)
        {
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Id", device.ModelId);
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "Id", device.InvoiceId);
            ViewData["LocalizationId"] = new SelectList(_context.Localization, "Id", "Id", device.LocalizationId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", device.StatusId);
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.SingleOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Id", device.ModelId);
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "Id", device.InvoiceId);
            ViewData["LocalizationId"] = new SelectList(_context.Localization, "Id", "Id", device.LocalizationId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", device.StatusId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,StatusId,UserId,Name,InvoiceId,LocalizationId")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
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
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Id", device.ModelId);
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "Id", device.InvoiceId);
            ViewData["LocalizationId"] = new SelectList(_context.Localization, "Id", "Id", device.LocalizationId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", device.StatusId);
            return View(device);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.DeviceModel)
                .Include(d => d.Invoice)
                .Include(d => d.Localization)
                .Include(d => d.Status)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Device.SingleOrDefaultAsync(m => m.Id == id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.Id == id);
        }
    }
}
