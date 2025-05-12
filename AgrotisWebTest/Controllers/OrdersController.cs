using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgrotisWebTest.Data;
using AgrotisWebTest.Models;
using AgrotisWebTest.Models.ViewModel;

namespace AgrotisWebTest.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DatabaseContext _context;

        public OrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.Products).ToListAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name");
            ViewBag.Products = _context.Products.ToList();

            var Orders = new Orders()
            {
                TotalPrice = 0,
                TotalWeight = 0,
                EmissionDatetime = DateTime.Now
            };

            return View(Orders);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel order)
        {
            order.Items = order.Items?.Where(i => i.Quantity > 0).ToList();
            order.EmissionDatetime = DateTime.Now;
            order.TotalPrice = 0.0;
            order.TotalWeight = 0.0;

            var listProducts = new List<Products>();
            foreach (var item in order.Items)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product != null)
                {
                    listProducts.Add(product);
                    order.TotalPrice += product.UnitaryPrice * item.Quantity;
                    order.TotalWeight += product.LiquidWeight * item.Quantity;
                }
            }

            var customer = _context.Customers.FirstOrDefault(c => c.Id == order.CustomerId);

            var newOrder = new Orders()
            {
                EmissionDatetime = order.EmissionDatetime,
                TotalPrice = order.TotalPrice,
                TotalWeight = order.TotalWeight,
                Products = listProducts,
                CustomerId = order.CustomerId,
                Customer = customer
            };

            if (newOrder != null)
            {
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmissionDatetime,TotalPrice,TotalWeight")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
