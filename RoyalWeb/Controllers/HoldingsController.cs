using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoyalWeb.Data;
using RoyalWeb.Models;

namespace RoyalWeb.Controllers
{
    public class HoldingsController : Controller
    {
        private readonly RoyalContext _context;

        public HoldingsController(RoyalContext context)
        {
            _context = context;
        }

        // GET: Holdings
        public async Task<IActionResult> Index()
        {
              return View(await _context.Holdings.ToListAsync());
        }

        // GET: Holdings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Holdings == null)
            {
                return NotFound();
            }

            var holding = await _context.Holdings
                .FirstOrDefaultAsync(m => m.HoldingId == id);
            if (holding == null)
            {
                return NotFound();
            }

            return View(holding);
        }

        // GET: Holdings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Holdings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoldingId,HoldingName")] Holding holding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holding);
        }

        // GET: Holdings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Holdings == null)
            {
                return NotFound();
            }

            var holding = await _context.Holdings.FindAsync(id);
            if (holding == null)
            {
                return NotFound();
            }
            return View(holding);
        }

        // POST: Holdings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoldingId,HoldingName")] Holding holding)
        {
            if (id != holding.HoldingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingExists(holding.HoldingId))
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
            return View(holding);
        }

        // GET: Holdings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Holdings == null)
            {
                return NotFound();
            }

            var holding = await _context.Holdings
                .FirstOrDefaultAsync(m => m.HoldingId == id);
            if (holding == null)
            {
                return NotFound();
            }

            return View(holding);
        }

        // POST: Holdings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Holdings == null)
            {
                return Problem("Entity set 'RoyalContext.Holdings'  is null.");
            }
            var holding = await _context.Holdings.FindAsync(id);
            if (holding != null)
            {
                _context.Holdings.Remove(holding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingExists(int id)
        {
          return _context.Holdings.Any(e => e.HoldingId == id);
        }
    }
}
