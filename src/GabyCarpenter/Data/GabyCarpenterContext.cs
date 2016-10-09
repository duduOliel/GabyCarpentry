using GabyCarpenter.Models.Carpentry;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tag>()
                .HasMany<ItemModel>(i => i.ItemModels)
                .with
                
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<Tag> tags { get; set; }
    }
}
