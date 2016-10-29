using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry.viewModel
{
    public class OrdersByItems
    {
        public IDictionary<string, List<OrderModel>> data { get; set; }
    }
}
