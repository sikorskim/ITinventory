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
    public class DeviceParametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceParametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceParameters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeviceParameter.Include(d => d.DeviceType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeviceParameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceParameter = await _context.DeviceParameter
                .Include(d => d.DeviceType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deviceParameter == null)
            {
                return NotFound();
            }

            return View(deviceParameter);
        }

        // GET: DeviceParameters/Create
        public IActionResult Create()
        {
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Name");
            return View();
        }

        // POST: DeviceParameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceTypeId,Name")] DeviceParameter deviceParameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Name", deviceParameter.DeviceTypeId);
            return View(deviceParameter);
        }

        // GET: DeviceParameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceParameter = await _context.DeviceParameter.SingleOrDefaultAsync(m => m.Id == id);
            if (deviceParameter == null)
            {
                return NotFound();
            }
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Id", deviceParameter.DeviceTypeId);
            return View(deviceParameter);
        }

        // POST: DeviceParameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceTypeId,Name")] DeviceParameter deviceParameter)
        {
            if (id != deviceParameter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceParameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceParameterExists(deviceParameter.Id))
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
            ViewData["DeviceTypeId"] = new SelectList(_context.DeviceType, "Id", "Id", deviceParameter.DeviceTypeId);
            return View(deviceParameter);
        }

        // GET: DeviceParameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceParameter = await _context.DeviceParameter
                .Include(d => d.DeviceType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deviceParameter == null)
            {
                return NotFound();
            }

            return View(deviceParameter);
        }

        // POST: DeviceParameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceParameter = await _context.DeviceParameter.SingleOrDefaultAsync(m => m.Id == id);
            _context.DeviceParameter.Remove(deviceParameter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceParameterExists(int id)
        {
            return _context.DeviceParameter.Any(e => e.Id == id);
        }
    }
}
