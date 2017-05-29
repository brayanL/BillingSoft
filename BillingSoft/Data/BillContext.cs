using BillingSoft.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingSoft.Data
{
    public class BillContext : DbContext
    {
        public BillContext(DbContextOptions<BillContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<BillPurchase> BillPurchase { get; set; }
        public DbSet<DetailBillPurchase> DetailBillPurchase { get; set; }
        public DbSet<DetailMovement> DetailMovement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.State).HasDefaultValue(true);
        }
    }
}
