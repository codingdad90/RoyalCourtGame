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
    public class PalacesController : Controller
    {
        private readonly RoyalContext _context;

        public PalacesController(RoyalContext context)
        {
            _context = context;
        }

        // GET: Palaces
        public async Task<IActionResult> Index()
        {
              return View(await _context.Palaces.ToListAsync());
        }

        // GET: Palaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Palaces == null)
            {
                return NotFound();
            }

            var palace = await _context.Palaces
                .FirstOrDefaultAsync(m => m.PalaceId == id);
            if (palace == null)
            {
                return NotFound();
            }

            return View(palace);
        }

        // GET: Palaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Palaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PalaceId,PalaceName")] Palace palace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(palace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(palace);
        }

        // GET: Palaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Palaces == null)
            {
                return NotFound();
            }

            var palace = await _context.Palaces.FindAsync(id);
            if (palace == null)
            {
                return NotFound();
            }
            return View(palace);
        }

        // POST: Palaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PalaceId,PalaceName")] Palace palace)
        {
            if (id != palace.PalaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(palace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalaceExists(palace.PalaceId))
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
            return View(palace);
        }

        // GET: Palaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Palaces == null)
            {
                return NotFound();
            }

            var palace = await _context.Palaces
                .FirstOrDefaultAsync(m => m.PalaceId == id);
            if (palace == null)
            {
                return NotFound();
            }

            return View(palace);
        }

        // POST: Palaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Palaces == null)
            {
                return Problem("Entity set 'RoyalContext.Palaces'  is null.");
            }
            var palace = await _context.Palaces.FindAsync(id);
            if (palace != null)
            {
                _context.Palaces.Remove(palace);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalaceExists(int id)
        {
          return _context.Palaces.Any(e => e.PalaceId == id);
        }
    }
}
