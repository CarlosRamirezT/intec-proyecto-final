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
    public class PaymentsController : Controller
    {
        private readonly GeneralDbContext _context;

        public PaymentsController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payments.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceId,Amount,Date")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payments);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            ViewBag.Invoice = new SelectList(_context.Invoices, "Id", "Id", payments.InvoiceId);
            return View(payments);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceId,Amount,Date")] Payments payments)
        {
            if (id != payments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    payments.InvoiceId = int.Parse(HttpContext.Request.Form["Invoice"]);
                    _context.Update(payments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsExists(payments.Id))
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
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payments = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
