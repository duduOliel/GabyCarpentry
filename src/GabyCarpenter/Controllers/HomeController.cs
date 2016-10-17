using GabyCarpenter.Data;
using GabyCarpenter.Models.Carpentry.viewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Controllers
{
    public class HomeController : Controller
    {

        private readonly GabyCarpenterContext _context;

        public HomeController(GabyCarpenterContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Random rand = new Random();

            HomeViewModel homeViewModel = new HomeViewModel();

            var items = await _context.Items.Include(i => i.Image).ToArrayAsync();
            while (homeViewModel.ItemsForCarousel.Count < (4 < items.Length ? 4 : items.Length))
            {
                var index = rand.Next(items.Length);
                if (!homeViewModel.ItemsForCarousel.Contains(items[index]))
                {
                    homeViewModel.ItemsForCarousel.Add(items[index]);
                }
            }

            homeViewModel.tags = _context.Items.SelectMany(m => m.tags.Split(',')).Distinct().ToList();
            homeViewModel.colors = _context.Items.Select(m => m.Color).Distinct().ToList();
            homeViewModel.inStock = new List<string>
            {
                "yes", "no"
            };

            homeViewModel.filteredtems = _context.Items.ToList();

            return View(homeViewModel);
        }


        public IActionResult Search(ICollection<string> tags, ICollection<string> colors, ICollection<string> inStock)
        {
            var matchingFilter = _context.Items.Include(m => m.Image)
                .Where(c => colors.Contains(c.Color))
                .Where(s => (inStock.Contains("yes") && s.amountInStock > 0) || (inStock.Contains("no") && s.amountInStock == 0))
                .ToList()
                .Where(i => i.tags.ToString().Split(',').Intersect(tags).Any());

            return Json(new { items = matchingFilter.Select(q => q.Id).ToArray() , colors = matchingFilter.Select(m=>m.Color).ToArray()});
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
