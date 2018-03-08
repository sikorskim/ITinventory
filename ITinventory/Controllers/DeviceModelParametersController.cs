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
    public class DeviceModelParametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceModelParametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceModelParameters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeviceModelParameter.Include(d => d.DeviceModel).Include(d => d.DeviceParameter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeviceModelParameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceModelParameter = await _context.DeviceModelParameter
                .Include(d => d.DeviceModel)
                .Include(d => d.DeviceParameter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deviceModelParameter == null)
            {
                return NotFound();
            }

            return View(deviceModelParameter);
        }

        // GET: DeviceModelParameters/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Name");
            ViewData["ParameterId"] = new SelectList(_context.DeviceParameter, "Id", "Name");
            return View();
        }

        // POST: DeviceModelParameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,ParameterId,Value")] DeviceModelParameter deviceModelParameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceModelParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Name", deviceModelParameter.ModelId);
            ViewData["ParameterId"] = new SelectList(_context.DeviceParameter, "Id", "Name", deviceModelParameter.ParameterId);
            return View(deviceModelParameter);
        }

        // GET: DeviceModelParameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceModelParameter = await _context.DeviceModelParameter.SingleOrDefaultAsync(m => m.Id == id);
            if (deviceModelParameter == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Id", deviceModelParameter.ModelId);
            ViewData["ParameterId"] = new SelectList(_context.DeviceParameter, "Id", "Id", deviceModelParameter.ParameterId);
            return View(deviceModelParameter);
        }

        // POST: DeviceModelParameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,ParameterId,Value")] DeviceModelParameter deviceModelParameter)
        {
            if (id != deviceModelParameter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceModelParameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceModelParameterExists(deviceModelParameter.Id))
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
            ViewData["ModelId"] = new SelectList(_context.DeviceModel, "Id", "Id", deviceModelParameter.ModelId);
            ViewData["ParameterId"] = new SelectList(_context.DeviceParameter, "Id", "Id", deviceModelParameter.ParameterId);
            return View(deviceModelParameter);
        }

        // GET: DeviceModelParameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceModelParameter = await _context.DeviceModelParameter
                .Include(d => d.DeviceModel)
                .Include(d => d.DeviceParameter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deviceModelParameter == null)
            {
                return NotFound();
            }

            return View(deviceModelParameter);
        }

        // POST: DeviceModelParameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceModelParameter = await _context.DeviceModelParameter.SingleOrDefaultAsync(m => m.Id == id);
            _context.DeviceModelParameter.Remove(deviceModelParameter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceModelParameterExists(int id)
        {
            return _context.DeviceModelParameter.Any(e => e.Id == id);
        }
    }
}
