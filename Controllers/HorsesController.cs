using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_s7.Data;
using Project_s7.Models;

namespace Project_s7.Controllers
{
    public class HorsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Horses
        public async Task<IActionResult> Index()
        {
              return _context.Horses != null ? 
                          View(await _context.Horses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Horses'  is null.");
        }

        // GET: Horses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Horses == null)
            {
                return NotFound();
            }

            var horses = await _context.Horses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horses == null)
            {
                return NotFound();
            }

            return View(horses);
        }

        // GET: Horses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Horses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HorseName,HorseType,HorseDescription,HorsePrice,HorsePictureLink")] Horses horses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horses);
        }

        // GET: Horses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Horses == null)
            {
                return NotFound();
            }

            var horses = await _context.Horses.FindAsync(id);
            if (horses == null)
            {
                return NotFound();
            }
            return View(horses);
        }

        // POST: Horses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HorseName,HorseType,HorseDescription,HorsePrice,HorsePictureLink")] Horses horses)
        {
            if (id != horses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorsesExists(horses.Id))
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
            return View(horses);
        }

        // GET: Horses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Horses == null)
            {
                return NotFound();
            }

            var horses = await _context.Horses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horses == null)
            {
                return NotFound();
            }

            return View(horses);
        }

        // POST: Horses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Horses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Horses'  is null.");
            }
            var horses = await _context.Horses.FindAsync(id);
            if (horses != null)
            {
                _context.Horses.Remove(horses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorsesExists(int id)
        {
          return (_context.Horses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
