using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_018_A.Models;

namespace UCP1_PAW_018_A.Controllers
{
    public class TransaksisController : Controller
    {
        private readonly CoffeeDBContext _context;

        public TransaksisController(CoffeeDBContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var coffeeDBContext = _context.Transaksis.Include(t => t.IdCustomerNavigation).Include(t => t.IdKasirNavigation).Include(t => t.IdMenuNavigation);
            return View(await coffeeDBContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdCustomerNavigation)
                .Include(t => t.IdKasirNavigation)
                .Include(t => t.IdMenuNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer");
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir");
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,IdMenu,IdCustomer,IdKasir,TotalTransaksi")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdCustomer);
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir", transaksi.IdKasir);
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu", transaksi.IdMenu);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdCustomer);
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir", transaksi.IdKasir);
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu", transaksi.IdMenu);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,IdMenu,IdCustomer,IdKasir,TotalTransaksi")] Transaksi transaksi)
        {
            if (id != transaksi.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.IdTransaksi))
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
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdCustomer);
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir", transaksi.IdKasir);
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu", transaksi.IdMenu);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdCustomerNavigation)
                .Include(t => t.IdKasirNavigation)
                .Include(t => t.IdMenuNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksis.FindAsync(id);
            _context.Transaksis.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksis.Any(e => e.IdTransaksi == id);
        }
    }
}
