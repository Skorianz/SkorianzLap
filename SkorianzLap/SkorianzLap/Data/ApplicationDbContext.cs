using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkorianzLap.Data.Models;
using SkorianzLap.Data.Models.Shop;

namespace SkorianzLap.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ProductEquipment> ProductEquipments { get; set; }
        public DbSet<OrderLineEquipment> OrderLineEquipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrderLine Primary Keys und Objektzuweisungen der Ids
            //modelBuilder.Entity<OrderLine>()
            //    .HasKey(t => new { t.OrderId, t.ProductId });

            //modelBuilder.Entity<OrderLine>()
            //    .HasOne(t3 => t3.Order)
            //    .WithMany()
            //    .HasForeignKey(t3 => t3.OrderId);

            //modelBuilder.Entity<OrderLine>()
            //    .HasOne(t3 => t3.Product)
            //    .WithMany()
            //    .HasForeignKey(t3 => t3.ProductId);

            // ProductEquipment Primary Keys und Objektzuweisungen der Ids
            modelBuilder.Entity<ProductEquipment>()
                .HasKey(t => new { t.ProductId, t.EquipmentProductId });

            modelBuilder.Entity<ProductEquipment>()
                .HasOne(t3 => t3.Product)
                .WithMany()
                .HasForeignKey(t3 => t3.ProductId);

            modelBuilder.Entity<ProductEquipment>()
                .HasOne(t3 => t3.EquipmentProduct)
                .WithMany()
                .HasForeignKey(t3 => t3.EquipmentProductId);

            // OrderLineEquipment Primary Keys und Objektzuweisungen der Ids
            modelBuilder.Entity<OrderLineEquipment>()
                .HasKey(t => new { t.OrderLineId, t.EquipmentProductId });

            modelBuilder.Entity<OrderLineEquipment>()
                .HasOne(t3 => t3.OrderLine)
                .WithMany()
                .HasForeignKey(t3 => t3.OrderLineId);

            modelBuilder.Entity<OrderLineEquipment>()
                .HasOne(t3 => t3.EquipmentProduct)
                .WithMany()
                .HasForeignKey(t3 => t3.EquipmentProductId);
        }
    }
}
