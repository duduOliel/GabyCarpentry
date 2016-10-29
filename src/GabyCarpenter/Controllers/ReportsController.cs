using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GabyCarpenter.Models.Carpentry.viewModel;
using GabyCarpenter.Data;
using Microsoft.EntityFrameworkCore;

namespace GabyCarpenter.Controllers
{
    public class ReportsController : Controller
    {
        private readonly GabyCarpenterContext _context;

        public ReportsController(GabyCarpenterContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrdersByItems()
        {
            return View(new OrdersByItems() {
            data = _context.Orders.Include(e => e.orderdItem).GroupBy(m => m.orderdItem).Select(s => new { key = s.FirstOrDefault().orderdItem.Name, value = s.ToList() }).ToDictionary(l => l.key, p => p.value)
        });
        }
    }
}