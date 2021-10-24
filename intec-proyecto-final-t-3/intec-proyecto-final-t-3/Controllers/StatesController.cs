using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using intec_proyecto_final_t_3.Models;
using System.Collections;

namespace intec_proyecto_final_t_3.Controllers
{
    public class StatesController : Controller
    {
        private readonly GeneralDbContext _context;

        public StatesController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: States
        public async Task<IActionResult> Index()
        {
            return View(await _context.States.ToListAsync());
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var states = await _context.States
                .FirstOrDefaultAsync(m => m.Id == id);
            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }

        // GET: States/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryId")] States states)
        {
            if (ModelState.IsValid)
            {
                _context.Add(states);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(states);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var states = await _context.States.FindAsync(id);
            if (states == null)
            {
                return NotFound();
            }
            ViewBag.Country = new SelectList(_context.Countries, "Id", "Name", states.CountryId);
            return View(states);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryId")] States states)
        {
            if (id != states.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    states.CountryId = int.Parse(HttpContext.Request.Form["Country"]);
                    _context.Update(states);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatesExists(states.Id))
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
            return View(states);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var states = await _context.States
                .FirstOrDefaultAsync(m => m.Id == id);
            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var states = await _context.States.FindAsync(id);
            _context.States.Remove(states);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatesExists(int id)
        {
            return _context.States.Any(e => e.Id == id);
        }
    }
}
