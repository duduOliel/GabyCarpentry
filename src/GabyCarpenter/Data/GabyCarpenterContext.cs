using GabyCarpenter.Models.Carpentry;
using GabyCarpenter.Models.Carpentry.Parts;
using Microsoft.EntityFrameworkCore;
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

    /*    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
      */  
        public DbSet<Part> parts { get; set; }
        public DbSet<ItemModel> items { get; set; }
    }
}
