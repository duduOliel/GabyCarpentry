using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GabyCarpenter.Data;
using GabyCarpenter.Models.Carpentry;
using Microsoft.AspNetCore.Http;
using System.IO;

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
            return View(await _context.Items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Color,Depth,Description,Height,Name,Price,Width,amountInStock,tags")] ItemModel itemModel,[Bind("Image")] ICollection<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                saveImages(itemModel, Image);
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemModel);
         }

        private void saveImages(ItemModel itemModel, ICollection<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var savedImage = new SavedImage();
                    savedImage.ContentType = file.ContentType;
                    savedImage.FileName = file.Name;
                    //var memStream = new MemoryStream();
                    using (var memStream = new MemoryStream())
                    {
                        file.CopyTo(memStream);
                        savedImage.Content = memStream.ToArray();
                    }

                    itemModel.Image.Add(savedImage);
                }
            }
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Color,Depth,Description,Height,Name,Price,Width,amountInStock,tags")] ItemModel itemModel)
        {
            if (id != itemModel.Id)
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
                    if (!ItemModelExists(itemModel.Id))
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

            var itemModel = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
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
            var itemModel = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
            _context.Items.Remove(itemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ItemModelExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
