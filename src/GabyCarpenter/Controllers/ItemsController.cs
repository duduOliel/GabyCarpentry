using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GabyCarpenter.Data;
using GabyCarpenter.Models.Carpentry;

namespace GabyCarpenter.Controllers
{
    public class ItemsController : Controller
    {
        private readonly GabyCarpenterContext _context;

        public ItemsController(GabyCarpenterContext context)
        {
            _context = context;    
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.items.SingleOrDefaultAsync(m => m.id == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,color,depth,description,height,images,name,price,width")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemModel);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.items.SingleOrDefaultAsync(m => m.id == id);
            if (itemModel == null)
            {
                return NotFound();
            }
            return View(itemModel);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,color,depth,description,height,images,name,price,width")] ItemModel itemModel)
        {
            if (id != itemModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.id))
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
            return View(itemModel);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.items.SingleOrDefaultAsync(m => m.id == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemModel = await _context.items.SingleOrDefaultAsync(m => m.id == id);
            _context.items.Remove(itemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ItemModelExists(int id)
        {
            return _context.items.Any(e => e.id == id);
        }
    }
}
