using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillingSoft.Data;
using BillingSoft.Models;

namespace BillingSoft.Controllers
{
    public class BillPurchasesController : Controller
    {
        private readonly BillContext _context;

        public BillPurchasesController(BillContext context)
        {
            _context = context;    
        }

        // GET: BillPurchases
        public async Task<IActionResult> Index()
        {
            var billContext = _context.BillPurchase.Include(b => b.Supplier);
            return View(await billContext.ToListAsync());
        }

        // GET: BillPurchases/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billPurchase = await _context.BillPurchase
                .Include(b => b.Supplier)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (billPurchase == null)
            {
                return NotFound();
            }

            return View(billPurchase);
        }

        // GET: BillPurchases/Create
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "ID", "ID");
            return View();
        }

        // POST: BillPurchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NumberBill,Date,Subtotal,Iva,Total,SupplierID")] BillPurchase billPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "ID", "ID", billPurchase.SupplierID);
            return View(billPurchase);
        }

        // GET: BillPurchases/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billPurchase = await _context.BillPurchase.SingleOrDefaultAsync(m => m.ID == id);
            if (billPurchase == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "ID", "ID", billPurchase.SupplierID);
            return View(billPurchase);
        }

        // POST: BillPurchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,NumberBill,Date,Subtotal,Iva,Total,SupplierID")] BillPurchase billPurchase)
        {
            if (id != billPurchase.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillPurchaseExists(billPurchase.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "ID", "ID", billPurchase.SupplierID);
            return View(billPurchase);
        }

        // GET: BillPurchases/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billPurchase = await _context.BillPurchase
                .Include(b => b.Supplier)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (billPurchase == null)
            {
                return NotFound();
            }

            return View(billPurchase);
        }

        // POST: BillPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var billPurchase = await _context.BillPurchase.SingleOrDefaultAsync(m => m.ID == id);
            _context.BillPurchase.Remove(billPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("GetInfoSupplier")]
        public ActionResult GetInfoSupplier(string ruc)
        {
            System.Diagnostics.Debug.WriteLine("RUC" + ruc);
            var result = _context.Supplier.SingleOrDefaultAsync(s=> s.Ruc == ruc);
            return Content(result.Result!=null ? result.Result.Name.ToString() : "null");
        }

        [HttpGet, ActionName("GetOneProduct")]
        public ActionResult GetOneProduct(string codigo)
        {
            var result = _context.Product.Where(p=> p.Code == codigo || p.Barcode == codigo);
            System.Diagnostics.Debug.WriteLine("codeProduct: "+ result);
            //return Content(result.ToString());
            return Json(result);
        }


        private bool BillPurchaseExists(long id)
        {
            return _context.BillPurchase.Any(e => e.ID == id);
        }
    }
}
