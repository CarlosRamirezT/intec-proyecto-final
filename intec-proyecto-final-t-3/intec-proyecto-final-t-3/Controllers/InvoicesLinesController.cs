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
    public class InvoicesLinesController : Controller
    {
        private readonly GeneralDbContext _context;

        public InvoicesLinesController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: InvoicesLines
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoicesLinesView.ToListAsync());
        }

        // GET: InvoicesLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicesLines = await _context.InvoicesLinesView
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoicesLines == null)
            {
                return NotFound();
            }

            return View(invoicesLines);
        }

        // GET: InvoicesLines/Create
        public IActionResult Create()
        {
            ViewBag.Product = new SelectList(_context.Products, "Id", "Name", 1);
            ViewBag.Invoice = new SelectList(_context.Invoices, "Id", "Id", 1);
            return View();
        }

        // POST: InvoicesLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,ProductId,Description,Quantity,UnitPrice,Subtotal")] InvoicesLines invoicesLines)
        {
            if (ModelState.IsValid)
            {
                invoicesLines.ProductId = int.Parse(HttpContext.Request.Form["Product"]);
                invoicesLines.InvoiceId = int.Parse(HttpContext.Request.Form["Invoice"]);
                _context.Add(invoicesLines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Details", "Invoices", new { id = invoicesLines.InvoiceId });
        }

        // GET: InvoicesLines/CreateFromInvoice
        public IActionResult CreateFromInvoice(int id)
        {
            ViewBag.Product = new SelectList(_context.Products, "Id", "Name", 1);
            ViewBag.Invoice = new SelectList(_context.Invoices, "Id", "Id", id);
            return View();
        }

        // POST: InvoicesLines/CreateFromInvoice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromInvoice([Bind("InvoiceId,CustomerId,ProductId,Description,Quantity,UnitPrice,Subtotal")] InvoicesLines invoicesLines)
        {
            if (ModelState.IsValid)
            {
                invoicesLines.ProductId = int.Parse(HttpContext.Request.Form["Product"]);
                invoicesLines.InvoiceId = int.Parse(HttpContext.Request.Form["Invoice"]);
                invoicesLines.Id = 0;
                _context.Add(invoicesLines);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Invoices", new { id = invoicesLines.InvoiceId });
            }
            return RedirectToAction("Details", "Invoices", new { id = invoicesLines.InvoiceId });
        }

        // GET: InvoicesLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicesLines = await _context.InvoicesLines.FindAsync(id);
            if (invoicesLines == null)
            {
                return NotFound();
            }
            ViewBag.Product = new SelectList(_context.Products, "Id", "Name", invoicesLines.ProductId);
            ViewBag.Invoice = new SelectList(_context.Invoices, "Id", "Id", invoicesLines.InvoiceId);
            return View(invoicesLines);
        }

        // POST: InvoicesLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,ProductId,Description,Quantity,UnitPrice,Subtotal")] InvoicesLines invoicesLines)
        {
            if (id != invoicesLines.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invoicesLines.ProductId = int.Parse(HttpContext.Request.Form["Product"]);
                    invoicesLines.InvoiceId = int.Parse(HttpContext.Request.Form["Invoice"]);
                    _context.Update(invoicesLines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesLinesExists(invoicesLines.Id))
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
            return View(invoicesLines);
        }

        // GET: tutisfrutis/Edit//Line/2
        public async Task<IActionResult> EditFromInvoice(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicesLines = await _context.InvoicesLines.FindAsync(id);
            if (invoicesLines == null)
            {
                return NotFound();
            }
            ViewBag.Product = new SelectList(_context.Products, "Id", "Name", invoicesLines.ProductId);
            ViewBag.Invoice = new SelectList(_context.Invoices, "Id", "Id", invoicesLines.InvoiceId);
            return View(invoicesLines);
        }

        // POST: tutisfrutis/Edit/Line/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFromInvoice(int id, [Bind("Id,InvoiceId,ProductId,Description,Quantity,UnitPrice,Subtotal")] InvoicesLines invoicesLines)
        {
            if (id != invoicesLines.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invoicesLines.ProductId = int.Parse(HttpContext.Request.Form["Product"]); ;
                    invoicesLines.InvoiceId = int.Parse(HttpContext.Request.Form["Invoice"]);
                    _context.Update(invoicesLines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesLinesExists(invoicesLines.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Invoices", new { id = invoicesLines.InvoiceId });
            }
            return RedirectToAction("Details", "Invoices", new { id = invoicesLines.InvoiceId });
        }

        // GET: InvoicesLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicesLines = await _context.InvoicesLinesView
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoicesLines == null)
            {
                return NotFound();
            }

            return View(invoicesLines);
        }

        // POST: InvoicesLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoicesLines = await _context.InvoicesLines.FindAsync(id);
            int InvoiceId = invoicesLines.InvoiceId;
            _context.InvoicesLines.Remove(invoicesLines);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Invoices", new { id = InvoiceId });
        }

        private bool InvoicesLinesExists(int id)
        {
            return _context.InvoicesLines.Any(e => e.Id == id);
        }
    }
}
