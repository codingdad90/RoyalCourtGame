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
    public class TitlesController : Controller
    {
        private readonly RoyalContext _context;

        public TitlesController(RoyalContext context)
        {
            _context = context;
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
              return View(await _context.Titles.ToListAsync());
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Titles == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .FirstOrDefaultAsync(m => m.TitleId == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,TitleName")] Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(title);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Titles == null)
            {
                return NotFound();
            }

            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,TitleName")] Title title)
        {
            if (id != title.TitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.TitleId))
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
            return View(title);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Titles == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .FirstOrDefaultAsync(m => m.TitleId == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Titles == null)
            {
                return Problem("Entity set 'RoyalContext.Titles'  is null.");
            }
            var title = await _context.Titles.FindAsync(id);
            if (title != null)
            {
                _context.Titles.Remove(title);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(int id)
        {
          return _context.Titles.Any(e => e.TitleId == id);
        }
    }
}
