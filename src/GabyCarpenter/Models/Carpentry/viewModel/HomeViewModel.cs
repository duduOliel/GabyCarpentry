using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry.viewModel
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            ItemsForCarousel = new List<ItemModel>();
            tags = new List<string>();
            inStock= new List<string>();
        }

        public ICollection<ItemModel> ItemsForCarousel { get; set; }
        public ICollection<string> tags { get; set; }
        public ICollection<string> colors { get; set; }
        public ICollection<string> inStock { get; set; }
        public ICollection<ItemModel> filteredtems { get; set; }
    }
}
