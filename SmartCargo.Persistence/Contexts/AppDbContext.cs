using Microsoft.EntityFrameworkCore;
using SmartCargo.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SmartCargo.Persistence.Contexts
{
    // Uygulamanın EF Core DbContext sınıfı
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Shipment tablosuna karşılık gelen DbSet
        public DbSet<Shipment> Shipments => Set<Shipment>();

        // Carrier tablosuna karşılık gelen DbSet
        public DbSet<Carrier> Carriers => Set<Carrier>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Shipment ile Carrier arasında bire-çok ilişki kuruluyor
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Carrier)
                .WithMany(c => c.Shipments)
                .HasForeignKey(s => s.CarrierId);
        }
    }
}
