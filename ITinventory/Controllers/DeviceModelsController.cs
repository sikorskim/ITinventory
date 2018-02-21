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
    public class DeviceModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeviceModel.Include(d => d.DeviceType).Include(d => d.Manufacturer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeviceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceModel = await _context.DeviceModel
                .Include(d => d.DeviceType)
                .Include(d => d.Manufacturer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deviceModel == null)
            {
                return NotFound();
            }

            return View(deviceModel);
        }

        // GET: DeviceModels/Create
        public IActionResult Create()
        {
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Id");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Id");
            return View();
        }

        // POST: DeviceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ManufacturerId,DeviceTypeId")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Id", deviceModel.DeviceTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Id", deviceModel.ManufacturerId);
            return View(deviceModel);
        }

        // GET: DeviceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceModel = await _context.DeviceModel.SingleOrDefaultAsync(m => m.Id == id);
            if (deviceModel == null)
            {
                return NotFound();
            }
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Id", deviceModel.DeviceTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Id", deviceModel.ManufacturerId);
            return View(deviceModel);
        }

        // POST: DeviceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ManufacturerId,DeviceTypeId")] DeviceModel deviceModel)
        {
            if (id != deviceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceModelExists(deviceModel.Id))
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
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Id", deviceModel.DeviceTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Id", deviceModel.ManufacturerId);
            return View(deviceModel);
        }

        // GET: DeviceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceModel = await _context.DeviceModel
                .Include(d => d.DeviceType)
                .Include(d => d.Manufacturer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deviceModel == null)
            {
                return NotFound();
            }

            return View(deviceModel);
        }

        // POST: DeviceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceModel = await _context.DeviceModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.DeviceModel.Remove(deviceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceModelExists(int id)
        {
            return _context.DeviceModel.Any(e => e.Id == id);
        }
    }
}
