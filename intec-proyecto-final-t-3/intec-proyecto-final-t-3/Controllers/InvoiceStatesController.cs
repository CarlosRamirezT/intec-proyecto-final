using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using intec_proyecto_final_t_3.Models;

namespace intec_proyecto_final_t_3.Controllers
{
    public class InvoiceStatesController : Controller
    {
        private readonly GeneralDbContext _context;

        public InvoiceStatesController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceStates.ToListAsync());
        }

        // GET: InvoiceStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceStates = await _context.InvoiceStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceStates == null)
            {
                return NotFound();
            }

            return View(invoiceStates);
        }

        // GET: InvoiceStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] InvoiceStates invoiceStates)
        {
            if (ModelState.IsValid)
            {
                invoiceStates.Id = 0;
                _context.Add(invoiceStates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceStates);
        }

        // GET: InvoiceStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceStates = await _context.InvoiceStates.FindAsync(id);
            if (invoiceStates == null)
            {
                return NotFound();
            }
            return View(invoiceStates);
        }

        // POST: InvoiceStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] InvoiceStates invoiceStates)
        {
            if (id != invoiceStates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceStates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceStatesExists(invoiceStates.Id))
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
            return View(invoiceStates);
        }

        // GET: InvoiceStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceStates = await _context.InvoiceStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceStates == null)
            {
                return NotFound();
            }

            return View(invoiceStates);
        }

        // POST: InvoiceStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceStates = await _context.InvoiceStates.FindAsync(id);
            _context.InvoiceStates.Remove(invoiceStates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceStatesExists(int id)
        {
            return _context.InvoiceStates.Any(e => e.Id == id);
        }
    }
}
