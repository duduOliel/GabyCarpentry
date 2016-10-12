using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GabyCarpenter.Data;
using Microsoft.EntityFrameworkCore;

namespace GabyCarpenter.Controllers
{
    public class SavedImagesController : Controller
    {
        private readonly GabyCarpenterContext _context;

        public SavedImagesController(GabyCarpenterContext context)
        {
            _context = context;
        }


        public IActionResult Index(int id)
        {
            var itemModel = _context.images.SingleOrDefault(m => m.FileId == id);
            return File(itemModel.Content, itemModel.ContentType);
        }
    }
}