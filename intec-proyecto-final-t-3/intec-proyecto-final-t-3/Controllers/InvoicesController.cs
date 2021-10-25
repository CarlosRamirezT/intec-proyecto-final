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
    public class InvoicesController : Controller
    {
        private readonly GeneralDbContext _context;

        public InvoicesController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoicesView.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.InvoicesView
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,StateId,DateInvoice,DateDue,AmountUntaxed,AmountTax,AmountTotal")] Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoices);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }
            ViewBag.State = new SelectList(_context.InvoiceStates, "Id", "Name", invoices.StateId);
            ViewBag.Customer = new SelectList(_context.Customers, "Id", "Name", invoices.CustomerId);
            return View(invoices);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,StateId,DateInvoice,DateDue,AmountUntaxed,AmountTax,AmountTotal")] Invoices invoices)
        {
            if (id != invoices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invoices.StateId = int.Parse(HttpContext.Request.Form["State"]);
                    invoices.CustomerId = int.Parse(HttpContext.Request.Form["Customer"]);
                    _context.Update(invoices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesExists(invoices.Id))
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
            return View(invoices);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicesExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
