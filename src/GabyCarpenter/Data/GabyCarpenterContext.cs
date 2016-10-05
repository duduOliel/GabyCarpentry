using GabyCarpenter.Models.Carpentry;
using Microsoft.EntityFrameworkCore;
using Models.Carpentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Data
{
    public class GabyCarpenterContext : DbContext
    {
        public GabyCarpenterContext(DbContextOptions options) : base(options)
        {
        }
        public GabyCarpenterContext()
        {

        }

        public DbSet<ItemModel> items { get; set; }
        public DbSet<Part> parts { get; set; }
    }
}
