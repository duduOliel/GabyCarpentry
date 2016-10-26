using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GabyCarpenter.Data;
using GabyCarpenter.Models.Carpentry;
using Microsoft.AspNetCore.Authorization;

namespace GabyCarpenter.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly GabyCarpenterContext _context;

        public OrdersController(GabyCarpenterContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            ViewBag.addreess = _context.Orders
                .Where(m => m.status == OrderStatus.Ready)
                .Select(k => k.SheepingAddress)
                .ToArray();
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders.Include(p => p.orderdItem).ThenInclude(j => j.Image).SingleOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // GET: Orders/Create
        [AllowAnonymous]
        [Route("Orders/create/{itemId:int}")]
        public IActionResult Create(int itemId)
        {
            ViewBag.item = _context.Items.Include(p => p.Image).SingleOrDefault(m => m.Id == itemId);
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Orders/create/{itemId:int}")]
        public async Task<IActionResult> Create([Bind("Id,SheepingAddress,clientName,phoneNumber")] OrderModel orderModel, int itemId)
        {
            if (ModelState.IsValid)
            {
                orderModel.status = OrderStatus.New;
                orderModel.orderdItem = _context.Items.FirstOrDefault(m => m.Id == itemId);

                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details/" + orderModel.Id);
            }
            return RedirectToAction("index", "Home", null);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }
            return View(orderModel);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SheepingAddress,clientName,phoneNumber,status")] OrderModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelExists(orderModel.Id))
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
            return View(orderModel);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrderModelExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string orderId, string orderedItem, string name)
        {
            return View(await _context.Orders
                .Include(l => l.orderdItem)
                .Where(m => orderId != null ? m.Id == int.Parse(orderId) : true)
                .Where(l => orderedItem != null ? l.orderdItem.Id == int.Parse(orderedItem) : true)
                .Where(p => name != null ? p.clientName == name : true)
                .ToListAsync());
        }
    }
}
